using Microsoft.Extensions.DependencyInjection;
using SeedWork.Services;

namespace SeedWork
{
    public static class Extends
    {
        public static IServiceCollection AddCannon(this IServiceCollection services)
        {
            services.AddSingleton<CannonService>();

            return services;
        }
    }
}