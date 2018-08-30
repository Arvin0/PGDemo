using Microsoft.Extensions.DependencyInjection;
using System;

namespace PGDemo.DependencyInjection.IocFlag
{
    public static class ServiceManagement
    {
        private static IServiceProvider _serviceProvider;

        public static IServiceCollection SetServiceProvider(this IServiceCollection service)
        {
            _serviceProvider = service.BuildServiceProvider();
            return service;
        }

        public static TService GetService<TService>(Type type) where TService : class, new()
        {
            var service = _serviceProvider.GetService(type);
            if (service != null && service is TService instance)
            {
                return instance;
            }

            return null;
        }
    }
}
