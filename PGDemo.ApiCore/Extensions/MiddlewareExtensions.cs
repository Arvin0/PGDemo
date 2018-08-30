using Microsoft.AspNetCore.Builder;
using PGDemo.ApiCore.Middleware;

namespace PGDemo.ApiCore.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandle(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandleMiddleware>();
        }

        public static IApplicationBuilder StatisticExecutedTime(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExecutedTimeMiddleware>();
        }
    }
}
