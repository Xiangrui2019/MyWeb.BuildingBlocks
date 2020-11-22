using Handler.Abstract.Interfaces;
using Handler.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Handler
{
    public static class Extends
    {
        public static IServiceCollection AddReporter<T>(this IServiceCollection services) where T : class, IReporter
        {
            services.AddSingleton<IReporter, T>();

            return services;
        }
        
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