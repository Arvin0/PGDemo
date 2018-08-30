using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using PGDemo.AOP.Interceptor;
using PGDemo.DependencyInjection.IocFlag;
using PGDemo.Infrastructure.Helper;
using System;
using System.Linq;
using System.Reflection;

namespace PGDemo.AOP
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 启动AOP
        /// </summary>
        /// <param name="service"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static IServiceProvider GetAutofacServiceProvider(this IServiceCollection service, string searchPattern)
        {
            var builder = new ContainerBuilder();
            builder.Populate(service);

            var assemblies = AssemblyHelper.GetAssemblies(searchPattern);

            // 注入实体类实现
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => typeof(IInstanceDependency).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                .InstancePerLifetimeScope();

            // 注入接口
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => typeof(IDependency).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LogInterceptor))
                .InterceptedBy(typeof(TimeStasticInterceptor));

            return new AutofacServiceProvider(builder.Build());
        }
    }
}
