using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWorkStudy_1.Repositories
{
    public class SqlServerRepository<T> : IRepository<T>, IDisposable where T : class
    {
        public IDbConnection dbConnection;

        public SqlServerRepository()
        {
            dbConnection = GetConnection();
        }

        private IDbConnection GetConnection()
        {
            return DbConnectionFactory.Instance.GetConnection();
        }

        public virtual IEnumerable<T> Query(string executeSql, object parameters)
        {
            try
            {
                return dbConnection.Query<T>(executeSql, parameters);
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return new List<T>();
        }

        public virtual IEnumerable<T> GetList()
        {
            try
            {
                return dbConnection.GetList<T>();
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return new List<T>();
        }

        public virtual IEnumerable<T> GetList(Expression<Func<T, object>> expression, Operator op, object param)
        {
            try
            {
                return dbConnection.GetList<T>(Predicates.Field<T>(expression, op, param));
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return new List<T>();
        }

        public virtual T Get(object id)
        {
            try
            {
                return dbConnection.Get<T>(id);
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return default(T);
        }

        public virtual bool Update(T t)
        {
            try
            {
                return dbConnection.Update<T>(t);
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return false;
        }

        public virtual T Insert(T t)
        {
            try
            {
                return dbConnection.Insert<T>(t);
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return default(T);
        }

        public virtual bool Delete(T t)
        {
            try
            {
                return dbConnection.Delete<T>(t);
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return false;

        }

        public T FirstOrDefault(Expression<Func<T, object>> expression, Operator op, object param)
        {
            try
            {
                return dbConnection.GetList<T>(Predicates.Field<T>(expression, op, param)).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return default(T);
        }

        public void Dispose()
        {
            this.dbConnection.Close();
            this.dbConnection.Dispose();
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return dbConnection.Query<T>();
            }
            catch (System.Exception ex)
            {
                // Handle and log error
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }

            return new List<T>().AsQueryable();
        }
    }

    public static class RepositoryExtensions
    {
        public static IQueryable<T> Query<T>(this IDbConnection dbConnection)
        {
            return null;
        }

        public static IQueryable<T> Where<T>(this IDbConnection dbConnection, Expression expression)
        {
            return null;
        }
    }
}
