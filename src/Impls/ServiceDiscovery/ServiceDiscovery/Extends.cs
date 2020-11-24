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
            where TRegistor : class, IServiceRegister 
            where TEndpointsGetter : class, IServiceEndpointsGetter
        {
            services.AddSingleton<IServiceEndpointsGetter, TEndpointsGetter>();
            services.AddSingleton<IServiceRegister, TRegistor>();
            
            return services;
        }

        public static IApplicationBuilder UseServiceRegister(this IApplicationBuilder app)
        {
            var registorService = app.ApplicationServices.GetService<IServiceRegister>();
            registorService.RegisterServiceAsync().GetAwaiter().GetResult();
            
            return app;
        }
    }
}