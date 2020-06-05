using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    /// <summary>
    /// 用于演示表达式树的作用
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Lambda表达式树
            Sample1.Demonstration();
            #endregion

            #region 组合表达式树
            Sample2.Demonstration();
            #endregion

            #region 调用一个类型的一个方法
            Sample3.Demonstration();
            #endregion

            Console.ReadKey();
        }
    }

    class Sample1
    {
        internal static void Demonstration()
        {
            Expression<Func<double, double, double>> distanceCalc = (x, y) => Math.Sqrt(x * x + y * y);

            var d1 = distanceCalc.Compile();

            Console.WriteLine(d1(3, 4));
        }
    }

    class Sample2
    {
        internal static void Demonstration()
        {
            var xParameter = Expression.Parameter(typeof(double), "x");
            var yParameter = Expression.Parameter(typeof(double), "y");
            var xSquared = Expression.Multiply(xParameter, xParameter);
            var ySquared = Expression.Multiply(yParameter, yParameter);
            var sum2 = Expression.Add(xSquared, ySquared);
            var sqrtMethod = typeof(Math).GetMethod("Sqrt", new[] { typeof(double) });
            var distance = Expression.Call(sqrtMethod, sum2);
            var d2 = (Func<double, double, double>)Expression.Lambda(distance, xParameter, yParameter).Compile();

            Console.WriteLine(d2(3, 4));
        }
    }

    class Sample3
    {
        internal static void Demonstration()
        {
            var code = "1";
            var list = new List<TestClass>() { new TestClass { Code = "1", Name = "1" }, new TestClass { Code = "2", Name = "2" } };
            var tc = Expression.Parameter(typeof(TestClass), "tc");
            var propertyaccess = Expression.PropertyOrField(tc, "Code");
            var body = Expression.Equal(propertyaccess, Expression.Constant("1"));
            var lambda = Expression.Lambda(body, tc);

            Console.WriteLine(lambda);

            var query = list.Where((Func<TestClass, bool>)lambda.Compile());

            Console.WriteLine(JsonConvert.SerializeObject(query));

            var input = Expression.Parameter(typeof(string), "Input");
            var input2 = Expression.Parameter(typeof(string), "Input2");
            var print = Expression.Call(null, typeof(TestClass).GetMethod("Print"), new Expression[] { input, input2 });

            var d2 = (Func<string, string, string>)Expression.Lambda(print, input, input2).Compile();

            Console.WriteLine(d2("1", "2"));
        }

        class TestClass
        {
            public string Code { get; set; }

            public string Name { get; set; }

            public static string Print(string input, string input2)
            {
                return input + input2;
            }
        }
    }
}
