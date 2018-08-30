using AspectCore.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PGDemo.DependencyInjection;
using PGDemo.DependencyInjection.Attributes;

namespace PGDemo.AOP.AspectCore.Interceptor
{
    public class LogInterceptor : AbstractInterceptor, IDependency
    {
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            if (GetLogAttributeInfo(context.ImplementationMethod) != null)
            {
                Console.WriteLine($"Begin {context.Implementation.ToString()}, {context.ImplementationMethod.Name}, {context.Proxy.ToString()}, {context.ProxyMethod.Name}");
            }
            
            return next(context);
        }

        private LogAttribute GetLogAttributeInfo(MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttributes(true).FirstOrDefault(s => s.GetType() == typeof(LogAttribute)) as
                LogAttribute;
        }
    }
}
