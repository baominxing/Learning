using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = "1";
            var list = new List<TestClass>() { new TestClass { Code = "1", Name = "1" }, new TestClass { Code = "2", Name = "2" } };
            var tc = Expression.Parameter(typeof(TestClass), "tc");
            var propertyaccess = Expression.PropertyOrField(tc, "Code");
            var variable = Expression.Variable(typeof(string), "Code");
            var assign = Expression.Assign(variable, Expression.Constant("1"));
            Console.WriteLine(assign);
            var body = Expression.Equal(propertyaccess, Expression.Constant(code));
            var lambda = Expression.Lambda(body, tc);

            Console.WriteLine(lambda);

            var query = list.Where((Func<TestClass, bool>)lambda.Compile());

            var input = Expression.Parameter(typeof(string), "Input");
            var input2 = Expression.Parameter(typeof(string), "Input2");
            var print = Expression.Call(null, typeof(TestClass).GetMethod("Print"), new Expression[] { input, input2 });

            var d2 = (Func<string, string, string>)Expression.Lambda(print, input, input2).Compile();

            Console.WriteLine(d2("1", "2"));

            Console.WriteLine();

            Console.ReadKey();

        }
    }


    public class TestClass
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public static string Print(string input, string input2)
        {
            return input + input2;
        }
    }
}
