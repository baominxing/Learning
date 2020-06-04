using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CastleInterceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new ProxyGenerator(); //实例化代理

            //var testinstance = (TestClass)proxy.CreateClassProxy(typeof(TestClass), new MyInterceptor());
            //testinstance.TestMethod("william");

            //var testinstance = (TestClass)proxy.CreateClassProxy(typeof(TestClass), new[] { "123", "123" }, new MyInterceptor2());
            //testinstance.TestMethod2();

            //var testinstance = (TestClass)proxy.CreateClassProxy(typeof(TestClass),new[] { typeof(ITestClass)}, ProxyGenerationOptions.Default, new[] { "123", "123" }, new MyInterceptor2());
            //testinstance.TestMethod3();

            //var testinstance = (TestClass)proxy.CreateClassProxyWithTarget(typeof(TestClass), new TestClass("123", "321"), ProxyGenerationOptions.Default, new[] { "456", "654" }, new MyInterceptor2());
            //testinstance.TestMethod3();

            //var testinstance = (ITestClass)proxy.CreateInterfaceProxyWithoutTarget(typeof(ITestClass), new MyInterceptor3());
            //testinstance.TestMethod3();

            ITestClass testClass = new TestClass("123", "456");

            //var testinstance = proxy.CreateInterfaceProxyWithTarget(testClass, new MyInterceptor3());
            //testinstance.TestMethod3();

            var testinstance = (ITestClass)proxy.CreateInterfaceProxyWithTargetInterface(typeof(ITestClass), testClass, new MyInterceptor3());
            testinstance.TestMethod3();

            Console.ReadLine();
        }
    }

    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("【进入拦截器】MyInterceptor");
            MethodInfo method = invocation.GetConcreteMethod();//得到被拦截的方法
            var parameter = invocation.Arguments[0].ToString();//获取被拦截的方法参数
            if (!invocation.MethodInvocationTarget.IsAbstract)
            {
                Console.WriteLine("【被拦截的方法执行前】" + method.Name + "的参数" + parameter);

                try
                {
                    invocation.Proceed();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("【拦截到异常】" + ex.Message);
                }
                Console.WriteLine("【被拦截的方法执结果】" + invocation.ReturnValue);

            }
            Console.WriteLine("【被拦截的方法执完毕】");
        }
    }


    public class MyInterceptor2 : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("【进入拦截器】MyInterceptor2");
            MethodInfo method = invocation.GetConcreteMethod();//得到被拦截的方法
            if (!invocation.MethodInvocationTarget.IsAbstract)
            {
                try
                {
                    invocation.Proceed();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("【拦截到异常】" + ex.Message);
                }
                Console.WriteLine("【被拦截的方法执结果】" + invocation.ReturnValue);

            }
            Console.WriteLine("【被拦截的方法执完毕】");
        }
    }

    public class MyInterceptor3 : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("【进入拦截器】MyInterceptor3");
            MethodInfo method = invocation.GetConcreteMethod();//得到被拦截的方法
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {

                Console.WriteLine("【拦截到异常】" + ex.Message);
            }
            Console.WriteLine("【被拦截的方法执结果】" + invocation.ReturnValue);
            Console.WriteLine("【被拦截的方法执完毕】");
        }
    }

    public class TestClass : ITestClass
    {
        private readonly string message;

        public TestClass()
        {
        }


        public TestClass(string message, string name)
        {
            this.message = message;
        }


        public virtual void TestMethod(string message)
        {
            //throw new Exception("异常了"); //演示抛出异常，拦截器是否能捕捉到异常信息
            Console.WriteLine(message);
        }

        public virtual void TestMethod2()
        {
            //throw new Exception("异常了"); //演示抛出异常，拦截器是否能捕捉到异常信息
            Console.WriteLine(this.message);
        }

        public virtual void TestMethod3()
        {
            //throw new Exception("异常了"); //演示抛出异常，拦截器是否能捕捉到异常信息
            Console.WriteLine(this.message);
        }
    }

    public interface ITestClass
    {
        void TestMethod3();
    }
}