using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ExpressionTree
{
    /// <summary>
    /// 用于演示表达式树的作用
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 访问一个类型的字段值
            //Sample1.Demonstration();
            #endregion

            #region 访问一个类型的属性值
            Sample2.Demonstration();
            #endregion

            #region 访问一个类型的方法
            //Sample3.Demonstration();
            #endregion

            Console.ReadKey();
        }
    }

    class Sample1
    {
        class T
        {
            public string Code;
        }

        static List<Expression> exps = new List<Expression>();

        internal static void Demonstration()
        {
            T t = new T() { Code = "Hello" };

            Expression type = Expression.Constant(typeof(T));

            exps.Add(type);

            Expression instance = Expression.Constant(t);

            exps.Add(instance);

            FieldInfo fieldInfo = t.GetType().GetField("Code");

            MemberExpression memberExpression = Expression.Field(instance, fieldInfo);

            exps.Add(memberExpression);

            LambdaExpression lambdaExpression = Expression.Lambda(memberExpression);

            exps.Add(lambdaExpression);

            Delegate d = lambdaExpression.Compile();

            Console.WriteLine(d.DynamicInvoke());

            //类似于此种访问方式：Func<string> s = () => t.Code;

            PrintExpression(exps);

        }

        static void PrintExpression(List<Expression> exps)
        {
            foreach (var item in exps)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Sample2
    {
        class T
        {
            public string Code;
        }

        static List<Expression> exps = new List<Expression>();

        internal static void Demonstration()
        {
            T t = new T() { Code = "Hello" };

            Expression type = Expression.Constant(typeof(T));

            exps.Add(type);

            ParameterExpression parameterExpression = Expression.Parameter(t.GetType(), "s");

            exps.Add(parameterExpression);

            FieldInfo fieldInfo = t.GetType().GetField("Code");

            MemberExpression memberExpression = Expression.Field(parameterExpression, fieldInfo);

            exps.Add(memberExpression);

            LambdaExpression lambdaExpression = Expression.Lambda(memberExpression, parameterExpression);

            exps.Add(lambdaExpression);

            Delegate d = lambdaExpression.Compile();

            Console.WriteLine(d.DynamicInvoke(t));

            //类似于此种访问方式：Func<T,string> ft = s => s.Code;

            PrintExpression(exps);

        }

        static void PrintExpression(List<Expression> exps)
        {
            foreach (var item in exps)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Sample3
    {
        class T
        {
            public string Code { get; set; }

            public void Print(string code)
            {
                Console.WriteLine(code);
            }
        }

        static List<Expression> exps = new List<Expression>();

        internal static void Demonstration()
        {
            T t = new T() { Code = "Hello" };

            Expression type = Expression.Constant(typeof(T));

            exps.Add(type);

            ParameterExpression parameterExpression = Expression.Parameter(t.GetType(), "s");

            exps.Add(parameterExpression);

            MethodInfo mi = t.GetType().GetMethod("Print");

            MethodCallExpression methodCallExpression = Expression.Call(parameterExpression, mi,Expression.Constant("Hello"));

            exps.Add(methodCallExpression);

            LambdaExpression lambdaExpression = Expression.Lambda(methodCallExpression, parameterExpression);

            exps.Add(lambdaExpression);

            Delegate d = lambdaExpression.Compile();

            Console.WriteLine(d.DynamicInvoke(t));

            //类似于此种访问方式：Action<T> ft = s => s.Print("Hello");

            PrintExpression(exps);
        }

        static void PrintExpression(List<Expression> exps)
        {
            foreach (var item in exps)
            {
                Console.WriteLine(item);
            }
        }
    }
}
