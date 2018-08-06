using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PGDemo.Common;

namespace PGDemo.ApiCore.Extensions
{
    public static class ConfiguratoinExtensions
    {
        public static IServiceCollection SetConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            ConfigHelper.Init(configuration);
            return service;
        }
    }
}
