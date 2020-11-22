using System;
using System.Net;
using Consul;
using DnsClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ServiceDiscovery.Consul.Models;

namespace ServiceDiscovery.Consul
{
    public static class Extends
    {
        public static IServiceCollection AddConsul(this IServiceCollection services)
        {
            services.AddSingleton<IConsulClient>(sp => {
                var client = new ConsulClient();
                var serviceConfig = sp.GetRequiredService<IOptions<ServiceDiscoveryOptions>>().Value;

                if (!string.IsNullOrWhiteSpace(serviceConfig.Consul.HttpEndpoint))
                {
                    //如果未配置，client将是使用默认的值：127.0.0.1:8500
                    client.Config.Address = new Uri(serviceConfig.Consul.HttpEndpoint);
                }
                return client;
            });
            
            services.AddSingleton<IDnsQuery>(sp =>
            {
                var serviceConfig = sp.GetRequiredService<IOptions<ServiceDiscoveryOptions>>().Value;

                var client = new LookupClient(IPAddress.Parse("127.0.0.1"), 8600);

                if (serviceConfig.Consul.DnsEndpoint != null)
                {
                    client = new LookupClient(serviceConfig.Consul.DnsEndpoint.ToIPEndPoint());
                }
                
                client.EnableAuditTrail = false;
                client.UseCache = true;
                client.MinimumCacheTimeout = TimeSpan.FromSeconds(1);

                return client;
            });

            return services;
        }
    }
}