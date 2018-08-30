using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Microsoft.Extensions.DependencyInjection;
using PGDemo.AOP.AspectCore.Interceptor;
using PGDemo.DependencyInjection;
using System;

namespace PGDemo.AOP.AspectCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider GetServiceProvider(this IServiceCollection service)
        {
            var container = service.ToServiceContainer();

            container.Configure(config =>
            {
                config.Interceptors.AddTyped<LogInterceptor>(method => typeof(IDependency).IsAssignableFrom(method.DeclaringType));
            });

            return container.Build();
        }
    }
}
