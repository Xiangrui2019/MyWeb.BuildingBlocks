using LoadBalancer.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace LoadBalancer
{
    public static class Extends
    {
        public static IServiceCollection AddLoadBalancer<TLb>(this IServiceCollection services)
            where TLb : class, ILoadBalancer
        {
            services.AddSingleton<ILoadBalancer, TLb>();
            
            return services;
        }
    }
}