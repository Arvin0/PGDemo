using Castle.DynamicProxy;
using System;
using System.Diagnostics;
using PGDemo.DependencyInjection.IocFlag;

namespace PGDemo.AOP.Interceptor
{
    public class TimeStasticInterceptor : IInterceptor, IInstanceDependency
    {
        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            invocation.Proceed();

            stopwatch.Stop();
            var flag = $"{invocation.TargetType.Name }:{invocation.Method.Name}";
            Console.WriteLine($"{flag} spend: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
