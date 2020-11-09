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
using System.Transactions;

namespace Dappers
{
    class Program
    {
        static void Main(string[] args)
        {
            //比较ADO.NET,Dapper,EF,IQToolkit查询100w+数据的效率比较
            //Sample1.Demonstration();

            //UnitOfWork 和 Repository 实现
            Sample2.Denomination();

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

    public class Sample2
    {
        public static void Denomination()
        {
            var unitOfWorkFactory = new UnitOfWorkFactory<SqlConnection>("your connection string");
            var db = new DbContext(unitOfWorkFactory);

            Products product = null;

            try
            {
                product = db.Product.Read(1);

                db.Commit();
            }
            catch (SqlException ex)
            {
                //log exception
                db.Rollback();
            }
        }

        public interface IUnitOfWorkFactory
        {
            UnitOfWork Create();
        }

        public class UnitOfWorkFactory<TConnection> : IUnitOfWorkFactory where TConnection : IDbConnection, new()
        {
            private string connectionString;

            public UnitOfWorkFactory(string connectionString)
            {
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException("connectionString cannot be null");
                }

                this.connectionString = connectionString;
            }

            public UnitOfWork Create()
            {
                return new UnitOfWork(CreateOpenConnection());
            }

            private IDbConnection CreateOpenConnection()
            {
                var conn = new TConnection();
                conn.ConnectionString = connectionString;

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception("An error occured while connecting to the database. See innerException for details.", exception);
                }

                return conn;
            }
        }

        public interface IDbContext
        {
            IProductRepository Product { get; }

            void Commit();

            void Rollback();
        }

        public class DbContext : IDbContext
        {
            private IUnitOfWorkFactory unitOfWorkFactory;

            private UnitOfWork unitOfWork;

            private IProductRepository product { get; set; }

            public DbContext(IUnitOfWorkFactory unitOfWorkFactory)
            {
                this.unitOfWorkFactory = unitOfWorkFactory;
            }

            public IProductRepository Product => product ?? (product = new ProductRepository(UnitOfWork));

            protected UnitOfWork UnitOfWork => unitOfWork ?? (unitOfWork = unitOfWorkFactory.Create());

            public void Commit()
            {
                try
                {
                    UnitOfWork.Commit();
                }
                finally
                {
                    Reset();
                }
            }

            public void Rollback()
            {
                try
                {
                    UnitOfWork.Rollback();
                }
                finally
                {
                    Reset();
                }
            }

            private void Reset()
            {
                unitOfWork = null;
                product = null;
            }
        }

        public interface IUnitOfWork
        {
            IDbTransaction Transaction { get; }

            void Commit();

            void Rollback();
        }

        public class UnitOfWork : IUnitOfWork
        {
            private IDbTransaction transaction;

            public UnitOfWork(IDbConnection connection)
            {
                transaction = connection.BeginTransaction();
            }

            public IDbTransaction Transaction => transaction;

            public void Commit()
            {
                try
                {
                    transaction.Commit();
                    transaction.Connection?.Close();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    transaction?.Dispose();
                    transaction.Connection?.Dispose();
                    transaction = null;
                }
            }

            public void Rollback()
            {
                try
                {
                    transaction.Rollback();
                    transaction.Connection?.Close();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    transaction?.Dispose();
                    transaction.Connection?.Dispose();
                    transaction = null;
                }
            }
        }

        public interface IProductRepository
        {
            Products Read(int id);
        }

        public class ProductRepository : IProductRepository
        {
            protected readonly IDbConnection connection;
            protected readonly IDbTransaction transaction;

            public ProductRepository(UnitOfWork unitOfWork)
            {
                connection = unitOfWork.Transaction.Connection;
                transaction = unitOfWork.Transaction;
            }

            public Products Read(int id)
            {
                return connection.QuerySingleOrDefault<Products>("select * from dbo.Product where Id = @id", new { id }, transaction);
            }
        }
    }
}
