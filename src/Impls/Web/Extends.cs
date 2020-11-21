using Microsoft.Extensions.DependencyInjection;
using Web.Services;

namespace Web
{
    public static class Extends
    {
        public static IServiceCollection AddCSVGenerator(this IServiceCollection services)
        {
            services.AddTransient<CSVGenerator>();
            return services;
        }
    }
}