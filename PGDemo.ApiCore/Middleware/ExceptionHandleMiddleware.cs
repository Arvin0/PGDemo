using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace PGDemo.ApiCore.Middleware
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await HandleExceptionAsync(context, context.Response.StatusCode, e.ToString());
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = string.Empty;
                switch (statusCode)
                {
                    case 401:
                        msg = "未授权";
                        break;
                    case 404:
                        msg = "未找到服务";
                        break;
                    case 502:
                        msg = "请求错误";
                        break;
                    default: break;
                }

                if (statusCode != 200)
                {
                    msg = "未知错误";
                }

                if (!string.IsNullOrEmpty(msg))
                {
                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, int statusCode, string msg)
        {
            var data = new {code = statusCode.ToString(), is_success = false, msg = msg};
            var result = JsonConvert.SerializeObject(new {data = data});
            context.Response.ContentType = "application/json;charset=utf-8";
            return context.Response.WriteAsync(result);
        }
    }
}
