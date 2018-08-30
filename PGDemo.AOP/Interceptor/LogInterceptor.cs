using Castle.DynamicProxy;
using System;
using PGDemo.DependencyInjection.IocFlag;

namespace PGDemo.AOP.Interceptor
{
    public class LogInterceptor : IInterceptor, IInstanceDependency
    {
        public void Intercept(IInvocation invocation)
        {
            var flag = $"{invocation.TargetType.Name }:{invocation.Method.Name}";
            Console.WriteLine($"Begin {flag}");

            invocation.Proceed();
            
            Console.WriteLine($"End {flag}");

        }
    }
}
