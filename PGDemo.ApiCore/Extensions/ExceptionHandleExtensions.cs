using Microsoft.AspNetCore.Builder;
using PGDemo.ApiCore.Middleware;

namespace PGDemo.ApiCore.Extensions
{
    public static class ExceptionHandleExtensions
    {
        public static IApplicationBuilder UseExceptionHandle(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandleMiddleware>();
        }
    }
}
