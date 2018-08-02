using Microsoft.Extensions.DependencyInjection;
using PGDemo.DependencyInjection;
using PGDemo.Infrastructure.Helper;
using System.Linq;

namespace PGDemo.ApiCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, string searchPattern)
        {
            var assemblies = AssemblyHelper.GetAssemblies(searchPattern);
            if (assemblies.Any())
            {
                var baseType = typeof(IDependency);
                foreach (var assembly in assemblies)
                {
                    var types = assembly.ExportedTypes.Where(
                        type => !type.IsAbstract && baseType.IsAssignableFrom(type));
                    if (types.Any())
                    {
                        foreach (var type in types)
                        {
                            var serviceType = type.GetInterfaces().FirstOrDefault(instanceType => baseType.IsAssignableFrom(instanceType));
                            if (serviceType != null)
                            {
                                services.AddScoped(serviceType, type);
                            }
                        }
                    }
                }
            }

            return services;
        }
    }
}
