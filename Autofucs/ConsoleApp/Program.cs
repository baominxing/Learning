using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using the TYPED attribute:
            var builder = new ContainerBuilder();
            builder.RegisterType<First>()
                   .EnableClassInterceptors();
            builder.Register(c => new CallLogger(Console.Out));

            var container = builder.Build();

            var first = container.Resolve<First>();

            first.GetValue();

            // Using the NAMED attribute:
            //var builder = new ContainerBuilder();
            //builder.RegisterType<Second>()
            //       .EnableClassInterceptors();
            //builder.Register(c => new CallLogger(Console.Out))
            //       .Named<IInterceptor>("log-calls");
        }
    }

    public class CallLogger : IInterceptor
    {
        TextWriter _output;

        public CallLogger(TextWriter output)
        {
            _output = output;
        }

        public void Intercept(IInvocation invocation)
        {
            _output.Write("Calling method {0} with parameters {1}... ",
              invocation.Method.Name,
              string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();

            _output.WriteLine("Done: result was {0}.", invocation.ReturnValue);
        }
    }

    // This attribute will look for a TYPED
    // interceptor registration:
    [Intercept(typeof(CallLogger))]
    public class First
    {
        public int GetValue()
        {
            // Do some calculation and return a value

            return 1;
        }
    }

    // This attribute will look for a NAMED
    // interceptor registration:
    [Intercept("log-calls")]
    public class Second
    {
        public virtual int GetValue()
        {
            return 2;
        }
    }
}
