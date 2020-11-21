using Handler.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Handler
{
    public static class Extends
    {
        public static IApplicationBuilder AddApiFriendlyExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiFriendlyExceptionMiddleware>();

            return app;
        }
        
        public static IApplicationBuilder AddApiFriendlyNotFoundHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiFriendlyNotFoundMiddleware>();

            return app;
        }
    }
}