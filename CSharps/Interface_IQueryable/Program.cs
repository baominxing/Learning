using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

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
        internal static void Demonstration()
        {
        }

        class Query : IQueryable
        {
            public Expression Expression => throw new NotImplementedException();

            public Type ElementType => throw new NotImplementedException();

            public IQueryProvider Provider => throw new NotImplementedException();

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        class QueryProvider : IQueryProvider
        {
            public IQueryable CreateQuery(Expression expression)
            {
                throw new NotImplementedException();
            }

            public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            {
                throw new NotImplementedException();
            }

            public object Execute(Expression expression)
            {
                throw new NotImplementedException();
            }

            public TResult Execute<TResult>(Expression expression)
            {
                throw new NotImplementedException();
            }
        }
    }
}