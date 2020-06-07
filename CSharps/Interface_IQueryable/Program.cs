using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Interface_IQueryable
{
    /// <summary>
    /// 用于演示IEnumable接口的用法及实现
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Sample1.Demonstration();

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True";

        internal static void Demonstration()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var dbset = new Query<StateInfos>(new QueryProvider(connection));

                Console.WriteLine(dbset.Expression);

                var query = dbset.Where(s => s.Code == "Free");

                foreach (var item in query)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        class Query<T> : IQueryable<T>
        {
            public Expression Expression { get; set; }

            public Type ElementType
            {
                get { return typeof(T); }
            }

            public IQueryProvider Provider { get; set; }

            public Query(IQueryProvider queryProvider)
            {
                this.Expression = Expression.Constant(this);
                this.Provider = queryProvider;
            }

            public Query(Expression expression, IQueryProvider queryProvider)
            {
                this.Expression = expression;
                this.Provider = queryProvider;
            }

            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)this.Provider.Execute(this.Expression)).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return this.Provider.Execute<IEnumerable<T>>(this.Expression).GetEnumerator();
            }

            public override string ToString()
            {
                //return this.Provider.GetQueryText(this.Expression);
                return string.Empty;
            }
        }

        class QueryProvider : IQueryProvider
        {
            IDbConnection connection;

            public QueryProvider(IDbConnection connection)
            {
                this.connection = connection;
            }

            public IQueryable CreateQuery(Expression expression)
            {
                throw new NotImplementedException();
            }

            public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            {
                return new Query<TElement>(expression, this);
            }

            public object Execute(Expression expression)
            {
                throw new NotImplementedException();
            }

            public TResult Execute<TResult>(Expression expression)
            {
                try
                {
                    IDbCommand cmd = this.connection.CreateCommand();
                    cmd.CommandText = new QueryTranslator().Translate(expression);
                    IDataReader reader = cmd.ExecuteReader();
                    Type elementType = TypeSystem.GetElementType(expression.Type);

                    return (TResult)Activator.CreateInstance(typeof(ObjectReader<>).MakeGenericType(elementType), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { reader }, null);
                }
                catch (Exception ex)
                {
                    throw new Exception($"查询报错{ex}");
                }
                finally
                {
                }

            }

            private string GetExecuteSql(Expression expression)
            {
                return "select * from stateinfos";
            }
        }

        class QueryTranslator : ExpressionVisitor
        {
            StringBuilder sb;
            ParameterExpression row;

            internal QueryTranslator() 
            {
            }
            internal string Translate(Expression expression)
            {
                this.sb = new StringBuilder();
                this.Visit(expression);
                return this.sb.ToString();
            }
            private static Expression StripQuotes(Expression e)
            {
                while (e.NodeType == ExpressionType.Quote)
                {
                    e = ((UnaryExpression)e).Operand;
                }
                return e;
            }
            protected override Expression VisitMethodCall(MethodCallExpression m)
            {
                if (m.Method.DeclaringType == typeof(Queryable))
                {
                    if (m.Method.Name == "Where")
                    {
                        sb.Append("SELECT * FROM (");
                        this.Visit(m.Arguments[0]);
                        sb.Append(") AS T WHERE ");
                        LambdaExpression lambda = (LambdaExpression)StripQuotes(m.Arguments[1]);
                        this.Visit(lambda.Body);
                        return m;
                    }
                }
                throw new NotSupportedException(string.Format("The method '{0}' is not supported", m.Method.Name));
            }
            protected override Expression VisitUnary(UnaryExpression u)
            {
                switch (u.NodeType)
                {
                    case ExpressionType.Not:
                        sb.Append(" NOT ");
                        this.Visit(u.Operand);
                        break;
                    default:
                        throw new NotSupportedException(string.Format("The unary operator '{0}' is not supported", u.NodeType));
                }
                return u;
            }
            protected override Expression VisitBinary(BinaryExpression b)
            {
                sb.Append("(");
                this.Visit(b.Left);
                switch (b.NodeType)
                {
                    case ExpressionType.And:
                        sb.Append(" AND ");
                        break;
                    case ExpressionType.Or:
                        sb.Append(" OR");
                        break;
                    case ExpressionType.Equal:
                        sb.Append(" = ");
                        break;
                    case ExpressionType.NotEqual:
                        sb.Append(" <> ");
                        break;
                    case ExpressionType.LessThan:
                        sb.Append(" < ");
                        break;
                    case ExpressionType.LessThanOrEqual:
                        sb.Append(" <= ");
                        break;
                    case ExpressionType.GreaterThan:
                        sb.Append(" > ");
                        break;
                    case ExpressionType.GreaterThanOrEqual:
                        sb.Append(" >= ");
                        break;
                    default:
                        throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
                }
                this.Visit(b.Right);
                sb.Append(")");
                return b;
            }
            protected override Expression VisitConstant(ConstantExpression c)
            {
                IQueryable q = c.Value as IQueryable;
                if (q != null)
                {
                    // assume constant nodes w/ IQueryables are table references
                    sb.Append("SELECT * FROM ");
                    sb.Append(q.ElementType.Name);
                }
                else if (c.Value == null)
                {
                    sb.Append("NULL");
                }
                else
                {
                    switch (Type.GetTypeCode(c.Value.GetType()))
                    {
                        case TypeCode.Boolean:
                            sb.Append(((bool)c.Value) ? 1 : 0);
                            break;
                        case TypeCode.String:
                            sb.Append("'");
                            sb.Append(c.Value);
                            sb.Append("'");
                            break;
                        case TypeCode.Object:
                            throw new NotSupportedException(string.Format("The constant for '{0}' is not supported", c.Value));
                        default:
                            sb.Append(c.Value);
                            break;
                    }
                }
                return c;
            }
            protected override Expression VisitMember(MemberExpression m)
            {
                if (m.Expression != null && m.Expression.NodeType == ExpressionType.Parameter)
                {
                    sb.Append(m.Member.Name);
                    return m;
                }
                throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));
            }
        }

        class ObjectReader<T> : IEnumerable<T> where T : class, new()
        {
            DbDataReader reader;
            FieldInfo[] fields;
            PropertyInfo[] properties;
            int[] fieldLookup;
            T current;

            internal ObjectReader(DbDataReader reader)
            {
                this.reader = reader;
                this.fields = typeof(T).GetFields();
                this.properties = typeof(T).GetProperties();

                this.InitFieldLookup();
            }

            public IEnumerator<T> GetEnumerator()
            {
                try
                {
                    while (this.reader.Read())
                    {
                        if (this.fieldLookup == null)
                        {
                            this.InitFieldLookup();
                        }

                        T instance = new T();

                        for (int i = 0, n = this.properties.Length; i < n; i++)
                        {
                            int index = this.fieldLookup[i];
                            if (index >= 0)
                            {
                                PropertyInfo fi = this.properties[i];
                                if (this.reader.IsDBNull(index))
                                {
                                    fi.SetValue(instance, null);
                                }
                                else
                                {
                                    fi.SetValue(instance, this.reader.GetValue(index));
                                }
                            }
                        }

                        this.current = instance;

                        yield return this.current;
                    }

                    Console.WriteLine("IEnumerator Over");

                    yield break;
                }
                finally
                {

                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            private void InitFieldLookup()
            {
                var map = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
                for (int i = 0, n = this.reader.FieldCount; i < n; i++)
                {
                    map.Add(this.reader.GetName(i), i);
                }
                this.fieldLookup = new int[this.properties.Length];
                for (int i = 0, n = this.properties.Length; i < n; i++)
                {
                    int index;
                    if (map.TryGetValue(this.properties[i].Name, out index))
                    {
                        this.fieldLookup[i] = index;
                    }
                    else
                    {
                        this.fieldLookup[i] = -1;
                    }
                }
            }
        }
    }

    static class TypeSystem
    {
        internal static Type GetElementType(Type seqType)
        {
            Type ienum = FindIEnumerable(seqType);
            if (ienum == null) return seqType;
            return ienum.GetGenericArguments()[0];
        }
        private static Type FindIEnumerable(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
                return null;
            if (seqType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
            if (seqType.IsGenericType)
            {
                foreach (Type arg in seqType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType))
                        return ienum;
                }
            }
            Type[] ifaces = seqType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0)
            {
                foreach (Type iface in ifaces)
                {
                    Type ienum = FindIEnumerable(iface);
                    if (ienum != null)
                        return ienum;
                }
            }
            if (seqType.BaseType != null && seqType.BaseType != typeof(object))
            {
                return FindIEnumerable(seqType.BaseType);
            }
            return null;
        }
    }
}