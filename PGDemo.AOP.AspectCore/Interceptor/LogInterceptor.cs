using AspectCore.DynamicProxy;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PGDemo.DependencyInjection;
using PGDemo.DependencyInjection.Attributes;

namespace PGDemo.AOP.AspectCore.Interceptor
{
    public class LogInterceptor : AbstractInterceptor, IDependency
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            await next(context);

            stopwatch.Stop();

            if (GetLogAttributeInfo(context.ImplementationMethod) != null)
            {
                Console.WriteLine(
                    $"Begin {context.Implementation.ToString()}, {context.ImplementationMethod.Name}, {context.Proxy.ToString()}, {context.ProxyMethod.Name}, {stopwatch.ElapsedMilliseconds}");
            }
        }

        private LogAttribute GetLogAttributeInfo(MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttributes(true).FirstOrDefault(s => s.GetType() == typeof(LogAttribute)) as
                LogAttribute;
        }
    }
}
