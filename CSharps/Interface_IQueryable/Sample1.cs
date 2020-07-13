using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Interface_IQueryable
{
    public class Sample1
    {
        private static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True";

        internal static void Demonstration()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var dbset = new Query<StateInfos>(new QueryProvider(connection));

                string Code = "Free";

                var query = dbset.Where(s => s.Code == Code);

                Console.WriteLine(query.ToString());

                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
            }
        }

        internal class Query<T> : IQueryable<T>
        {
            public Expression Expression { get; set; }

            public Type ElementType
            {
                get { return typeof(T); }
            }

            public IQueryProvider Provider { get; set; }

            public Query(QueryProvider queryProvider)
            {
                this.Provider = queryProvider;
                this.Expression = Expression.Constant(this);
            }

            public Query(QueryProvider queryProvider, Expression expression)
            {
                this.Provider = queryProvider;
                this.Expression = expression;
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
                return ((QueryProvider)this.Provider).GetQueryText(this.Expression);
            }
        }

        internal class QueryProvider : IQueryProvider
        {
            private IDbConnection connection;

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
                return new Query<TElement>(this, expression);
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

            public string GetQueryText(Expression expression)
            {
                return new QueryTranslator().Translate(expression);
            }
        }

        internal class QueryTranslator : ExpressionVisitor
        {
            private StringBuilder sb;

            internal QueryTranslator()
            {
                this.sb = new StringBuilder();
            }

            internal Expression GetExpression(Expression expression)
            {
                return this.Visit(expression);
            }

            internal string Translate(Expression expression)
            {
                expression = Evaluator.PartialEval(expression);

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
                    else if (m.Method.Name == "FirstOrDefault")
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

        internal class ObjectReader<T> : IEnumerable<T> where T : class, new()
        {
            private DbDataReader reader;
            private FieldInfo[] fields;
            private PropertyInfo[] properties;
            private int[] fieldLookup;
            private T current;

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

        internal class ExpressionVisitor
        {
            protected ExpressionVisitor()
            {
            }

            protected virtual Expression Visit(Expression exp)
            {
                if (exp == null)
                    return exp;
                switch (exp.NodeType)
                {
                    case ExpressionType.Negate:
                    case ExpressionType.NegateChecked:
                    case ExpressionType.Not:
                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                    case ExpressionType.ArrayLength:
                    case ExpressionType.Quote:
                    case ExpressionType.TypeAs:
                        return this.VisitUnary((UnaryExpression)exp);

                    case ExpressionType.Add:
                    case ExpressionType.AddChecked:
                    case ExpressionType.Subtract:
                    case ExpressionType.SubtractChecked:
                    case ExpressionType.Multiply:
                    case ExpressionType.MultiplyChecked:
                    case ExpressionType.Divide:
                    case ExpressionType.Modulo:
                    case ExpressionType.And:
                    case ExpressionType.AndAlso:
                    case ExpressionType.Or:
                    case ExpressionType.OrElse:
                    case ExpressionType.LessThan:
                    case ExpressionType.LessThanOrEqual:
                    case ExpressionType.GreaterThan:
                    case ExpressionType.GreaterThanOrEqual:
                    case ExpressionType.Equal:
                    case ExpressionType.NotEqual:
                    case ExpressionType.Coalesce:
                    case ExpressionType.ArrayIndex:
                    case ExpressionType.RightShift:
                    case ExpressionType.LeftShift:
                    case ExpressionType.ExclusiveOr:
                        return this.VisitBinary((BinaryExpression)exp);

                    case ExpressionType.TypeIs:
                        return this.VisitTypeIs((TypeBinaryExpression)exp);

                    case ExpressionType.Conditional:
                        return this.VisitConditional((ConditionalExpression)exp);

                    case ExpressionType.Constant:
                        return this.VisitConstant((ConstantExpression)exp);

                    case ExpressionType.Parameter:
                        return this.VisitParameter((ParameterExpression)exp);

                    case ExpressionType.MemberAccess:
                        return this.VisitMember((MemberExpression)exp);

                    case ExpressionType.Call:
                        return this.VisitMethodCall((MethodCallExpression)exp);

                    case ExpressionType.Lambda:
                        return this.VisitLambda((LambdaExpression)exp);

                    case ExpressionType.New:
                        return this.VisitNew((NewExpression)exp);

                    case ExpressionType.NewArrayInit:
                    case ExpressionType.NewArrayBounds:
                        return this.VisitNewArray((NewArrayExpression)exp);

                    case ExpressionType.Invoke:
                        return this.VisitInvocation((InvocationExpression)exp);

                    case ExpressionType.MemberInit:
                        return this.VisitMemberInit((MemberInitExpression)exp);

                    case ExpressionType.ListInit:
                        return this.VisitListInit((ListInitExpression)exp);

                    default:
                        throw new Exception(string.Format("Unhandled expression type: '{0}'", exp.NodeType));
                }
            }

            protected virtual MemberBinding VisitBinding(MemberBinding binding)
            {
                switch (binding.BindingType)
                {
                    case MemberBindingType.Assignment:
                        return this.VisitMemberAssignment((MemberAssignment)binding);

                    case MemberBindingType.MemberBinding:
                        return this.VisitMemberMemberBinding((MemberMemberBinding)binding);

                    case MemberBindingType.ListBinding:
                        return this.VisitMemberListBinding((MemberListBinding)binding);

                    default:
                        throw new Exception(string.Format("Unhandled binding type '{0}'", binding.BindingType));
                }
            }

            protected virtual ElementInit VisitElementInitializer(ElementInit initializer)
            {
                ReadOnlyCollection<Expression> arguments = this.VisitExpressionList(initializer.Arguments);
                if (arguments != initializer.Arguments)
                {
                    return Expression.ElementInit(initializer.AddMethod, arguments);
                }
                return initializer;
            }

            protected virtual Expression VisitUnary(UnaryExpression u)
            {
                Expression operand = this.Visit(u.Operand);
                if (operand != u.Operand)
                {
                    return Expression.MakeUnary(u.NodeType, operand, u.Type, u.Method);
                }
                return u;
            }

            protected virtual Expression VisitBinary(BinaryExpression b)
            {
                Expression left = this.Visit(b.Left);
                Expression right = this.Visit(b.Right);
                Expression conversion = this.Visit(b.Conversion);
                if (left != b.Left || right != b.Right || conversion != b.Conversion)
                {
                    if (b.NodeType == ExpressionType.Coalesce && b.Conversion != null)
                        return Expression.Coalesce(left, right, conversion as LambdaExpression);
                    else
                        return Expression.MakeBinary(b.NodeType, left, right, b.IsLiftedToNull, b.Method);
                }
                return b;
            }

            protected virtual Expression VisitTypeIs(TypeBinaryExpression b)
            {
                Expression expr = this.Visit(b.Expression);
                if (expr != b.Expression)
                {
                    return Expression.TypeIs(expr, b.TypeOperand);
                }
                return b;
            }

            protected virtual Expression VisitConstant(ConstantExpression c)
            {
                return c;
            }

            protected virtual Expression VisitConditional(ConditionalExpression c)
            {
                Expression test = this.Visit(c.Test);
                Expression ifTrue = this.Visit(c.IfTrue);
                Expression ifFalse = this.Visit(c.IfFalse);
                if (test != c.Test || ifTrue != c.IfTrue || ifFalse != c.IfFalse)
                {
                    return Expression.Condition(test, ifTrue, ifFalse);
                }
                return c;
            }

            protected virtual Expression VisitParameter(ParameterExpression p)
            {
                return p;
            }

            protected virtual Expression VisitMember(MemberExpression m)
            {
                Expression exp = this.Visit(m.Expression);
                if (exp != m.Expression)
                {
                    return Expression.MakeMemberAccess(exp, m.Member);
                }
                return m;
            }

            protected virtual Expression VisitMethodCall(MethodCallExpression m)
            {
                Expression obj = this.Visit(m.Object);
                IEnumerable<Expression> args = this.VisitExpressionList(m.Arguments);
                if (obj != m.Object || args != m.Arguments)
                {
                    return Expression.Call(obj, m.Method, args);
                }
                return m;
            }

            protected virtual ReadOnlyCollection<Expression> VisitExpressionList(ReadOnlyCollection<Expression> original)
            {
                List<Expression> list = null;
                for (int i = 0, n = original.Count; i < n; i++)
                {
                    Expression p = this.Visit(original[i]);
                    if (list != null)
                    {
                        list.Add(p);
                    }
                    else if (p != original[i])
                    {
                        list = new List<Expression>(n);
                        for (int j = 0; j < i; j++)
                        {
                            list.Add(original[j]);
                        }
                        list.Add(p);
                    }
                }
                if (list != null)
                {
                    return list.AsReadOnly();
                }
                return original;
            }

            protected virtual MemberAssignment VisitMemberAssignment(MemberAssignment assignment)
            {
                Expression e = this.Visit(assignment.Expression);
                if (e != assignment.Expression)
                {
                    return Expression.Bind(assignment.Member, e);
                }
                return assignment;
            }

            protected virtual MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding binding)
            {
                IEnumerable<MemberBinding> bindings = this.VisitBindingList(binding.Bindings);
                if (bindings != binding.Bindings)
                {
                    return Expression.MemberBind(binding.Member, bindings);
                }
                return binding;
            }

            protected virtual MemberListBinding VisitMemberListBinding(MemberListBinding binding)
            {
                IEnumerable<ElementInit> initializers = this.VisitElementInitializerList(binding.Initializers);
                if (initializers != binding.Initializers)
                {
                    return Expression.ListBind(binding.Member, initializers);
                }
                return binding;
            }

            protected virtual IEnumerable<MemberBinding> VisitBindingList(ReadOnlyCollection<MemberBinding> original)
            {
                List<MemberBinding> list = null;
                for (int i = 0, n = original.Count; i < n; i++)
                {
                    MemberBinding b = this.VisitBinding(original[i]);
                    if (list != null)
                    {
                        list.Add(b);
                    }
                    else if (b != original[i])
                    {
                        list = new List<MemberBinding>(n);
                        for (int j = 0; j < i; j++)
                        {
                            list.Add(original[j]);
                        }
                        list.Add(b);
                    }
                }
                if (list != null)
                    return list;
                return original;
            }

            protected virtual IEnumerable<ElementInit> VisitElementInitializerList(ReadOnlyCollection<ElementInit> original)
            {
                List<ElementInit> list = null;
                for (int i = 0, n = original.Count; i < n; i++)
                {
                    ElementInit init = this.VisitElementInitializer(original[i]);
                    if (list != null)
                    {
                        list.Add(init);
                    }
                    else if (init != original[i])
                    {
                        list = new List<ElementInit>(n);
                        for (int j = 0; j < i; j++)
                        {
                            list.Add(original[j]);
                        }
                        list.Add(init);
                    }
                }
                if (list != null)
                    return list;
                return original;
            }

            protected virtual Expression VisitLambda(LambdaExpression lambda)
            {
                Expression body = this.Visit(lambda.Body);
                if (body != lambda.Body)
                {
                    return Expression.Lambda(lambda.Type, body, lambda.Parameters);
                }
                return lambda;
            }

            protected virtual NewExpression VisitNew(NewExpression nex)
            {
                IEnumerable<Expression> args = this.VisitExpressionList(nex.Arguments);
                if (args != nex.Arguments)
                {
                    if (nex.Members != null)
                        return Expression.New(nex.Constructor, args, nex.Members);
                    else
                        return Expression.New(nex.Constructor, args);
                }
                return nex;
            }

            protected virtual Expression VisitMemberInit(MemberInitExpression init)
            {
                NewExpression n = this.VisitNew(init.NewExpression);
                IEnumerable<MemberBinding> bindings = this.VisitBindingList(init.Bindings);
                if (n != init.NewExpression || bindings != init.Bindings)
                {
                    return Expression.MemberInit(n, bindings);
                }
                return init;
            }

            protected virtual Expression VisitListInit(ListInitExpression init)
            {
                NewExpression n = this.VisitNew(init.NewExpression);
                IEnumerable<ElementInit> initializers = this.VisitElementInitializerList(init.Initializers);
                if (n != init.NewExpression || initializers != init.Initializers)
                {
                    return Expression.ListInit(n, initializers);
                }
                return init;
            }

            protected virtual Expression VisitNewArray(NewArrayExpression na)
            {
                IEnumerable<Expression> exprs = this.VisitExpressionList(na.Expressions);
                if (exprs != na.Expressions)
                {
                    if (na.NodeType == ExpressionType.NewArrayInit)
                    {
                        return Expression.NewArrayInit(na.Type.GetElementType(), exprs);
                    }
                    else
                    {
                        return Expression.NewArrayBounds(na.Type.GetElementType(), exprs);
                    }
                }
                return na;
            }

            protected virtual Expression VisitInvocation(InvocationExpression iv)
            {
                IEnumerable<Expression> args = this.VisitExpressionList(iv.Arguments);
                Expression expr = this.Visit(iv.Expression);
                if (args != iv.Arguments || expr != iv.Expression)
                {
                    return Expression.Invoke(expr, args);
                }
                return iv;
            }
        }

        internal static class Evaluator
        {
            /// <summary>

            /// Performs evaluation & replacement of independent sub-trees

            /// </summary>

            /// <param name="expression">The root of the expression tree.</param>

            /// <param name="fnCanBeEvaluated">A function that decides whether a given expression node can be part of the local function.</param>

            /// <returns>A new tree with sub-trees evaluated and replaced.</returns>

            public static Expression PartialEval(Expression expression, Func<Expression, bool> fnCanBeEvaluated)
            {
                var nominator = new Nominator(fnCanBeEvaluated);

                var candidates = nominator.Nominate(expression);

                var subtreeEvaluator = new SubtreeEvaluator(candidates);

                var newExpression = subtreeEvaluator.Eval(expression);

                return newExpression;
            }

            /// <summary>

            /// Performs evaluation & replacement of independent sub-trees

            /// </summary>

            /// <param name="expression">The root of the expression tree.</param>

            /// <returns>A new tree with sub-trees evaluated and replaced.</returns>

            public static Expression PartialEval(Expression expression)
            {
                return PartialEval(expression, Evaluator.CanBeEvaluatedLocally);
            }

            private static bool CanBeEvaluatedLocally(Expression expression)
            {
                return expression.NodeType != ExpressionType.Parameter;
            }

            /// <summary>

            /// Evaluates & replaces sub-trees when first candidate is reached (top-down)

            /// </summary>

            private class SubtreeEvaluator : ExpressionVisitor
            {
                private HashSet<Expression> candidates;

                internal SubtreeEvaluator(HashSet<Expression> candidates)
                {
                    this.candidates = candidates;
                }

                internal Expression Eval(Expression exp)
                {
                    return this.Visit(exp);
                }

                protected override Expression Visit(Expression exp)
                {
                    if (exp == null)
                    {
                        return null;
                    }

                    if (this.candidates.Contains(exp))
                    {
                        return this.Evaluate(exp);
                    }

                    return base.Visit(exp);
                }

                private Expression Evaluate(Expression e)
                {
                    if (e.NodeType == ExpressionType.Constant)
                    {
                        return e;
                    }


                    LambdaExpression lambda = Expression.Lambda(e);

                    Delegate fn = lambda.Compile();

                    var value = fn.DynamicInvoke(null);

                    //类似于此种访问方式：Func<string> s = () => t.Code;

                    return Expression.Constant(value, e.Type);
                }
            }

            /// <summary>

            /// Performs bottom-up analysis to determine which nodes can possibly

            /// be part of an evaluated sub-tree.

            /// </summary>

            private class Nominator : ExpressionVisitor
            {
                private Func<Expression, bool> fnCanBeEvaluated;

                private HashSet<Expression> candidates;

                private bool cannotBeEvaluated;

                internal Nominator(Func<Expression, bool> fnCanBeEvaluated)
                {
                    this.fnCanBeEvaluated = fnCanBeEvaluated;
                }

                internal HashSet<Expression> Nominate(Expression expression)
                {
                    this.candidates = new HashSet<Expression>();

                    this.Visit(expression);

                    return this.candidates;
                }

                protected override Expression Visit(Expression expression)
                {
                    if (expression != null)
                    {
                        bool saveCannotBeEvaluated = this.cannotBeEvaluated;

                        this.cannotBeEvaluated = false;

                        base.Visit(expression);

                        if (!this.cannotBeEvaluated)
                        {
                            if (this.fnCanBeEvaluated(expression))
                            {
                                this.candidates.Add(expression);
                            }
                            else
                            {
                                this.cannotBeEvaluated = true;
                            }
                        }

                        this.cannotBeEvaluated |= saveCannotBeEvaluated;
                    }

                    return expression;
                }
            }
        }
    }
}
