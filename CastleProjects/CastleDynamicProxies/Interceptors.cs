using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CastleDynamicProxies
{

    public class FreezableInterceptor : IInterceptor, IFreezable
    {
        public void Freeze()
        {
            IsFrozen = true;
        }

        public bool IsFrozen { get; private set; }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Intercept: {invocation.Method.Name}");

            if (IsFrozen && IsSetter(invocation.Method))
            {
                throw new ObjectFrozenException();
            }

            invocation.Proceed();
        }

        private static bool IsSetter(MethodInfo method)
        {
            return method.IsSpecialName && method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase);
        }
    }



    public class CallLoggingInterceptor : IInterceptor
    {
        public int Count { get; set; }

        public CallLoggingInterceptor()
        {
        }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("CallLoggingInterceptor...");

            invocation.Proceed();

            Count++;
        }
    }

    public class MethodInterceptor : IInterceptor
    {
        public readonly Delegate _impl;

        public MethodInterceptor(Delegate @delegate)
        {
            this._impl = @delegate;
        }

        public void Intercept(IInvocation invocation)
        {
            var result = this._impl.DynamicInvoke(invocation.Arguments);
            invocation.ReturnValue = result;
        }
    }

    public class DelegateWrapper
    {
        public static TInterface WrapAs<TInterface>(Delegate d1, Delegate d2)
        {
            var generator = new ProxyGenerator();
            var options = new ProxyGenerationOptions { Selector = new DelegateSelector() };
            var proxy = generator.CreateInterfaceProxyWithoutTarget(
                typeof(TInterface),
                new Type[0],
                options,
                new MethodInterceptor(d1),
                new MethodInterceptor(d2));
            return (TInterface)proxy;
        }
    }

    public class CheckNullInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Arguments[0] == null)
            {
                invocation.ReturnValue = 0;
                return;
            }
            invocation.Proceed();
        }
    }

    public class AdjustTimeToUtcInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var argument = (string)invocation.Arguments[0];
            DateTimeOffset result;
            if (DateTimeOffset.TryParse(argument, out result))
            {
                argument = result.UtcDateTime.ToString();
                invocation.Arguments[0] = argument;
            }
            try
            {
                invocation.Proceed();
            }
            catch (FormatException)
            {
                invocation.ReturnValue = 0;
            }
        }
    }
}
