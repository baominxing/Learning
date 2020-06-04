using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkStudy_1.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IEnumerable<T> Query(string executeSql, object parameters);

        IEnumerable<T> GetList();

        IEnumerable<T> GetList(Expression<Func<T, object>> expression, Operator op, object param);

        T FirstOrDefault(Expression<Func<T, object>> expression, Operator op, object param);

        T Get(object id);

        bool Update(T t);

        T Insert(T apply);

        bool Delete(T t);
    }
}
