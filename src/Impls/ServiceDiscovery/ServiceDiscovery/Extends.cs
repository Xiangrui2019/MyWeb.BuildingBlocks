using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscovery
{
    public static class Extends
    {
        public static IServiceCollection AddServiceResloverService<TReslover>(this IServiceCollection services) where TReslover : class, IServiceReslover
        {
            services.AddSingleton<IServiceReslover, TReslover>();
            
            return services;
        }

        public static IServiceCollection AddServiceRegistorService<TEndpointsGetter, TRegistor>(this IServiceCollection services)
            where TRegistor : class, IServiceRegistor 
            where TEndpointsGetter : class, IServiceEndpointsGetter
        {
            services.AddSingleton<IServiceEndpointsGetter, TEndpointsGetter>();
            services.AddSingleton<IServiceRegistor, TRegistor>();
            
            return services;
        }

        public static IApplicationBuilder UseServiceRegister(this IApplicationBuilder app)
        {
            var registorService = app.ApplicationServices.GetService<IServiceRegistor>();
            registorService.RegisterServiceAsync().GetAwaiter().GetResult();
            
            return app;
        }
    }
}