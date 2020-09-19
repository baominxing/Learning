using Dapper;
using DapperExtensions;
using Entities;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Dappers
{
    class Program
    {
        static void Main(string[] args)
        {
            //比较ADO.NET,Dapper,EF,IQToolkit查询100w+数据的效率比较
            Sample1.Demonstration();

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";
        public static void Demonstration()
        {
            var connectionFactory = new SqlConnectionFactory(connectionString);

            var stateInfoRepository = new DapperRepository<CutterParameters>(connectionFactory);

            var list = stateInfoRepository.GetList();
        }

        public interface IDbConnectionFactory
        {
            IDbConnection CreateConnection();
        }

        public class SqlConnectionFactory : IDbConnectionFactory
        {
            private readonly string _connectionString;

            public SqlConnectionFactory(string connectionString)
            {
                _connectionString = connectionString;
            }

            public IDbConnection CreateConnection()
            {
                var conn = new SqlConnection(_connectionString);

                conn.Open();
                return conn;
            }
        }

        public interface IDapperRepository<T> where T : class, IEntity
        {
            IEnumerable<T> Query(string executeSql, object parameters);

            IEnumerable<T> GetList();

            IEnumerable<T> GetList(Expression<Func<T, object>> expression, Operator op, object param);

            T FirstOrDefault(Expression<Func<T, object>> expression, Operator op, object param);

            T Get(object id);

            bool Update(T t);

            T Insert(T apply);

            bool Delete(T t);
        }

        public class DapperRepository<T> : IDapperRepository<T> where T : class, IEntity
        {
            private readonly IDbConnectionFactory dbConnectionFactory;

            public DapperRepository(IDbConnectionFactory dbConnectionFactory)
            {
                this.dbConnectionFactory = dbConnectionFactory;
            }

            public virtual IEnumerable<T> Query(string executeSql, object parameters)
            {
                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    if (typeof(T).IsAssignableFrom(typeof(ISoftDelete)))
                    {
                        Expression type = Expression.Constant(typeof(T));

                        Expression instance = Expression.Constant(dbConnection);

                        MethodInfo mi = typeof(T).GetType().GetMethod("Query");

                        MethodCallExpression methodCallExpression = Expression.Call(instance, mi, Expression.Constant(executeSql), Expression.Constant(parameters));

                        LambdaExpression lambdaExpression = Expression.Lambda(methodCallExpression);

                        Delegate d = lambdaExpression.Compile();

                        Console.WriteLine(d.DynamicInvoke());

                        return dbConnection.Query<T>(executeSql, parameters);//.Where(s => !s.IsDeleted);
                    }
                    else
                    {
                        return dbConnection.Query<T>(executeSql, parameters);
                    }
                }
            }


            public virtual IEnumerable<T> GetList()
            {
                IEnumerable<T> result = null;

                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    if (typeof(ISoftDelete).IsAssignableFrom(typeof(T)))
                    {
                        Expression type = Expression.Constant(typeof(T));

                        Expression instance = Expression.Constant(dbConnection);

                        var mi = dbConnection.GetType().GetMethod("Close");

                        MethodCallExpression methodCallExpression = Expression.Call(instance, mi);

                        LambdaExpression lambdaExpression = Expression.Lambda(methodCallExpression);

                        Delegate d = lambdaExpression.Compile();

                        Console.WriteLine(d.DynamicInvoke());

                        result = dbConnection.GetList<T>();//.Where(s => !s.IsDeleted).ToList();
                    }
                    else
                    {
                        result = dbConnection.GetList<T>().ToList();
                    }
                }

                return result;
            }

            public virtual IEnumerable<T> GetList(Expression<Func<T, object>> expression, Operator op, object param)
            {
                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    return dbConnection.GetList<T>(Predicates.Field<T>(expression, op, param));
                }
            }

            public virtual T Get(object id)
            {
                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    return dbConnection.Get<T>(id);
                }
            }

            public virtual bool Update(T t)
            {
                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    return dbConnection.Update(t);
                }
            }

            public virtual T Insert(T t)
            {
                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    return dbConnection.Insert(t);
                }
            }

            public virtual bool Delete(T t)
            {
                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    return dbConnection.Delete(t);
                }

            }

            public T FirstOrDefault(Expression<Func<T, object>> expression, Operator op, object param)
            {
                return this.GetList(expression, op, param).FirstOrDefault();
            }
        }
    }
}
