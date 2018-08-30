using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace PGDemo.ApiCore.Middleware
{
    public class ExecutedTimeMiddleware
    {
        private readonly ILogger<ExecutedTimeMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExecutedTimeMiddleware(RequestDelegate next, ILogger<ExecutedTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await _next(context);

            stopwatch.Stop();
            var message = $"{context.Request.GetDisplayUrl()} Time : {stopwatch.ElapsedMilliseconds}";
            Console.WriteLine(message);
            _logger.LogInformation(message);
        }

    }
}
