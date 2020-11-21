using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Handler.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SeedWork.ErrorCode;

namespace Handler.Middlewares
{
    public class ApiFriendlyExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiFriendlyExceptionMiddleware> _logger;

        public ApiFriendlyExceptionMiddleware(
            RequestDelegate next,
            ILogger<ApiFriendlyExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.Clear();
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json; charset=utf-8";
                    var message = JsonConvert.SerializeObject(
                        ReusltGenerator.GetServerExceptionResponse());
                    await context.Response.WriteAsync(message, Encoding.UTF8);
                    try
                    {
                        _logger.LogError(e, e.Message);
                    }
                    catch
                    {
                        // ignored
                    }

                    return;
                }
                throw;
            }
        }
    }
}