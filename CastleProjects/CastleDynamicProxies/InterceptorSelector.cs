using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CastleDynamicProxies
{
    public class FreezableInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //if (IsSetter(method))
            //    return interceptors;
            //return interceptors.Where(i => (i is FreezableInterceptor)).ToArray();

            return interceptors;
        }

        private bool IsSetter(MethodInfo method)
        {
            return method.IsSpecialName && method.Name.StartsWith("set_", StringComparison.Ordinal);
        }
    }

    public class DelegateSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            foreach (var interceptor in interceptors)
            {
                var methodInterceptor = interceptor as MethodInterceptor;
                if (methodInterceptor == null)
                    continue;
                var d = methodInterceptor._impl;
                if (IsEquivalent(d, method))
                    return new[] { interceptor };
            }
            throw new ArgumentException();
        }

        private static bool IsEquivalent(Delegate d, MethodInfo method)
        {
            var dm = d.Method;
            if (!method.ReturnType.IsAssignableFrom(dm.ReturnType))
                return false;
            var parameters = method.GetParameters();
            var dp = dm.GetParameters();
            if (parameters.Length != dp.Length)
                return false;
            for (int i = 0; i < parameters.Length; i++)
            {
                //BUG: does not take into account modifiers (like out, ref...)
                if (!parameters[i].ParameterType.IsAssignableFrom(dp[i].ParameterType))
                    return false;
            }
            return true;
        }
    }

    internal class TimeFixSelector : IInterceptorSelector
    {
        private static readonly MethodInfo[] methodsToAdjust =
            new[]
            {
            typeof(ITimeHelper).GetMethod("GetHour"),
            typeof(ITimeHelper).GetMethod("GetMinute")
            };
        private CheckNullInterceptor _checkNull = new CheckNullInterceptor();
        private AdjustTimeToUtcInterceptor _utcAdjust = new AdjustTimeToUtcInterceptor();

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if (!methodsToAdjust.Contains(method))
                return new IInterceptor[] { _checkNull }.Union(interceptors).ToArray();
            return new IInterceptor[] { _checkNull, _utcAdjust }.Union(interceptors).ToArray();
        }
    }
}
