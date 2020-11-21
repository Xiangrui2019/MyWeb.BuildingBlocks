using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Handler.Abstract.Interfaces;
using Handler.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SeedWork.ErrorCode;

namespace Handler.Middlewares
{
    public class ApiFriendlyExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiFriendlyExceptionMiddleware> _logger;
        private readonly IHostingEnvironment _environment;
        private readonly IReporter _reporter;

        public ApiFriendlyExceptionMiddleware(
            RequestDelegate next,
            ILogger<ApiFriendlyExceptionMiddleware> logger, 
            IHostingEnvironment environment,
            IReporter reporter)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
            _reporter = reporter;
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
                        ReusltGenerator.GetServerExceptionResponse(
                            e.StackTrace, _environment.IsDevelopment()));
                    await context.Response.WriteAsync(message, Encoding.UTF8);
                    try
                    {
                        _logger.LogError(e, e.Message);
                        
                        // 通过报告器报告给日志系统异常.
                        await _reporter.ReportAsync(context.Request.Path, e);
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