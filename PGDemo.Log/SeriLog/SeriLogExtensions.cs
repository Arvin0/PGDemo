using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Serilog;
using Serilog.Events;

namespace PGDemo.Log.SeriLog
{
    public static class SeriLogExtensions
    {
        /// <summary>
        /// 添加Serilo配置文件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddSerilog(this IConfigurationBuilder builder)
        {
            builder.AddJsonFile(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "serilogsettings.json"), 
                false, true);
            return builder;
        }

        /// <summary>
        /// IApplicationBuilder 扩展，添加Serilog到LogFactory
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterSerilog(this IApplicationBuilder app, ILoggerFactory loggerFactory, 
            IConfiguration configuration)
        {
            var serilog = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            loggerFactory.AddSerilog(serilog);

            return app;
        }
    }
}
