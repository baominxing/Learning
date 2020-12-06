using Autofac;
using Dapper;
using DapperExtensions;
using Entities;
using EntityFramework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Caching;
using System.Transactions;

namespace Dappers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Repository 实现
            Sample1.Demonstration();

            //UnitOfWork 和 Repository 实现
            //Sample2.Denomination();

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";

        public static void Demonstration()
        {
            var builder = new ContainerBuilder();

            //注册数据库连接工厂
            builder.RegisterType<SqlConnectionFactory>()
                .As<IDbConnectionFactory>()
                .WithParameter(new TypedParameter(typeof(string), connectionString))
                .SingleInstance();
            //注册dapper repository
            builder.RegisterGeneric(typeof(DapperRepository<>)).As(typeof(IDapperRepository<>)).InstancePerDependency();

            //获取state repository
            var container = builder.Build();
            var stateRepository = container.Resolve<IDapperRepository<TraceFlowSettings>>();

            //获取state表值

            Console.WriteLine(stateRepository.GetList().Count());

            Console.WriteLine(stateRepository.GetList(s => s.Id, Operator.Eq, 1));

            Console.WriteLine(stateRepository.GetList(s => s.Id, Operator.Eq, 1));
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

            public virtual IEnumerable<T> GetList()
            {
                IEnumerable<T> result = null;

                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    if (typeof(ISoftDelete).IsAssignableFrom(typeof(T)))
                    {
                        var executeSql = MemoryCacheHelper.GetOrAddCacheItem<string>(typeof(T).Name, () =>
                        {
                            var properties = typeof(T).GetProperties();
                            var tablename = typeof(T).Name;

                            return $"select {string.Join(",", properties.Select(s => s.Name))} from {tablename} where isdeleted = 0";
                        });

                        result = dbConnection.Query<T>(executeSql);
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
                IEnumerable<T> result = null;

                using (var dbConnection = dbConnectionFactory.CreateConnection())
                {
                    if (typeof(ISoftDelete).IsAssignableFrom(typeof(T)))
                    {
                        Func<T, bool> d = MemoryCacheHelper.GetOrAddCacheItem($"Func_{typeof(T).Name}", () =>
                        {
                            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "s");

                            PropertyInfo propertyInfo = typeof(T).GetProperty("IsDeleted");

                            MemberExpression memberExpression = Expression.Property(parameterExpression, propertyInfo);

                            BinaryExpression binaryExpression = Expression.MakeBinary(ExpressionType.Equal, memberExpression, Expression.Constant(true));

                            LambdaExpression lambdaExpression = Expression.Lambda(binaryExpression, parameterExpression);

                            return (Func<T, bool>)lambdaExpression.Compile();
                        });

                        result = dbConnection.GetList<T>(Predicates.Field(expression, op, param)).Where(d);
                    }
                    else
                    {
                        result = dbConnection.GetList<T>(Predicates.Field(expression, op, param));
                    }

                    return result;
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

        /// <summary>
        /// 内存缓存帮助类，支持绝对过期时间、滑动过期时间、文件依赖三种缓存方式。
        /// </summary>
        public class MemoryCacheHelper
        {
            private static readonly object _locker1 = new object(), _locker2 = new object();

            /// <summary>
            /// 取缓存项，如果不存在则返回空。
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            public static T GetCacheItem<T>(string key)
            {
                try
                {
                    return (T)MemoryCache.Default[key];
                }
                catch
                {
                    return default(T);
                }
            }

            /// <summary>
            /// 是否包含指定键的缓存项
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public static bool Contains(string key)
            {
                return MemoryCache.Default.Contains(key);
            }

            /// <summary>
            /// 取缓存项，如果不存在则新增缓存项。
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <param name="cachePopulate"></param>
            /// <param name="slidingExpiration"></param>
            /// <param name="absoluteExpiration"></param>
            /// <returns></returns>
            public static T GetOrAddCacheItem<T>(string key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
                //if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");
                //if (slidingExpiration == null && absoluteExpiration == null) throw new ArgumentException("Either a sliding expiration or absolute must be provided");

                if (MemoryCache.Default[key] == null)
                {
                    lock (_locker1)
                    {
                        if (MemoryCache.Default[key] == null)
                        {
                            T cacheValue = cachePopulate();
                            if (!typeof(T).IsValueType && cacheValue == null)   //如果是引用类型且为NULL则不存缓存
                            {
                                return cacheValue;
                            }

                            var item = new CacheItem(key, cacheValue);
                            var policy = CreatePolicy(slidingExpiration, absoluteExpiration);

                            MemoryCache.Default.Add(item, policy);
                        }
                    }
                }

                return (T)MemoryCache.Default[key];
            }

            /// <summary>
            /// 取缓存项，如果不存在则新增缓存项。
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <param name="cachePopulate"></param>
            /// <param name="dependencyFilePath"></param>
            /// <returns></returns>
            public static T GetOrAddCacheItem<T>(string key, Func<T> cachePopulate, string dependencyFilePath)
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
                if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");

                if (MemoryCache.Default[key] == null)
                {
                    lock (_locker2)
                    {
                        if (MemoryCache.Default[key] == null)
                        {
                            T cacheValue = cachePopulate();
                            if (!typeof(T).IsValueType && cacheValue == null)   //如果是引用类型且为NULL则不存缓存
                            {
                                return cacheValue;
                            }

                            var item = new CacheItem(key, cacheValue);
                            var policy = CreatePolicy(dependencyFilePath);

                            MemoryCache.Default.Add(item, policy);
                        }
                    }
                }

                return (T)MemoryCache.Default[key];
            }

            /// <summary>
            /// 指定缓存项的一组逐出和过期详细信息
            /// </summary>
            /// <param name="slidingExpiration"></param>
            /// <param name="absoluteExpiration"></param>
            /// <returns></returns>
            private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
            {
                var policy = new CacheItemPolicy();

                if (absoluteExpiration.HasValue)
                {
                    policy.AbsoluteExpiration = absoluteExpiration.Value;
                }
                else if (slidingExpiration.HasValue)
                {
                    policy.SlidingExpiration = slidingExpiration.Value;
                }

                policy.Priority = CacheItemPriority.Default;

                return policy;
            }

            /// <summary>
            /// 指定缓存项的一组逐出和过期详细信息
            /// </summary>
            /// <param name="filePath"></param>
            /// <returns></returns>
            private static CacheItemPolicy CreatePolicy(string filePath)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string>() { filePath }));
                policy.Priority = CacheItemPriority.Default;
                return policy;
            }

            /// <summary>
            /// 移除指定键的缓存项
            /// </summary>
            /// <param name="key"></param>
            public static void RemoveCacheItem(string key)
            {
                if (Contains(key))
                {
                    MemoryCache.Default.Remove(key);
                }
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
