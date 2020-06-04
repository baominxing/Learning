using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace CastleDynamicProxies
{
    public interface IFreezable
    {
        bool IsFrozen { get; }
        void Freeze();
    }

    public class Freezable //: IFreezable
    {
        private static readonly IInterceptorSelector _selector = new FreezableInterceptorSelector();
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        public static bool IsFreezable(object obj)
        {
            return AsFreezable(obj) != null;
        }

        public static bool IsFrozen(object obj)
        {
            var freezable = AsFreezable(obj);
            return freezable != null && freezable.IsFrozen;
        }

        public static TClass MakeFreezable<TClass>() where TClass : class, new()
        {
            var options = new ProxyGenerationOptions(new FreezableProxyGenerationHook()) { Selector = _selector };
            options.AddMixinInstance(new List<string>());
            var freezableInterceptor = new FreezableInterceptor();
            var proxy = Generator.CreateClassProxy<TClass>(options, freezableInterceptor, new CallLoggingInterceptor());
            return proxy;
        }

        public static void Freeze(object freezable)
        {
            var interceptor = AsFreezable(freezable);
            if (interceptor == null)
                throw new NotFreezableObjectException(freezable);
            interceptor.Freeze();
        }

        private static IFreezable AsFreezable(object target)
        {
            if (target == null)
                return null;
            var hack = target as IProxyTargetAccessor;
            if (hack == null)
                return null;
            return hack.GetInterceptors().FirstOrDefault(i => i is FreezableInterceptor) as IFreezable;
        }
    }

    [Serializable]
    public class NotFreezableObjectException : Exception
    {
        private object freezable;

        public NotFreezableObjectException()
        {
        }

        public NotFreezableObjectException(object freezable)
        {
            this.freezable = freezable;
        }

        public NotFreezableObjectException(string message) : base(message)
        {
        }

        public NotFreezableObjectException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFreezableObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }



    [Serializable]
    public class ObjectFrozenException : Exception
    {
        public ObjectFrozenException()
        {
        }

        public ObjectFrozenException(string message) : base(message)
        {
        }

        public ObjectFrozenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ObjectFrozenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
