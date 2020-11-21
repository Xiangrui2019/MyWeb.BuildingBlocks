using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SeedWork.ErrorCode;
using SeedWork.Models.Message;

namespace Handler.Middlewares
{
    public class ApiFriendlyNotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiFriendlyNotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == StatusCodes.Status404NotFound
                && !context.Response.HasStarted)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json; charset=utf-8";

                var message = JsonConvert.SerializeObject(new MessageModel
                {
                    Code = ErrorType.NotFound,
                    Message = "对不起, 我们找不到这个资源"
                });
                
                await context.Response.WriteAsync(message, Encoding.UTF8);
            }
        }
    }
}