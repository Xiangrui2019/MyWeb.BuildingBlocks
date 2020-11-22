using System;
using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceDiscovery.Consul
{
    public static class Extends
    {
        public static IServiceCollection AddConsul(this IServiceCollection services)
        {
            services.AddSingleton<IConsulClient>(sp => {
                var client = new ConsulClient();
                var serviceConfig = sp.GetRequiredService<IConfiguration>();

                if (!string.IsNullOrWhiteSpace(serviceConfig["ServiceDiscoveryOptions:Consul:HttpEndpoint"]))
                {
                    //如果未配置，client将是使用默认的值：127.0.0.1:8500
                    client.Config.Address = new Uri(serviceConfig["ServiceDiscoveryOptions:Consul:HttpEndpoint"]);
                }
                return client;
            });

            return services;
        }
    }
}