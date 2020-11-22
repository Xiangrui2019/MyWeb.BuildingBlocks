using System;
using System.Threading.Tasks;
using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscovery.Consul.Services
{
    public class ConsulServiceRegistor : IServiceRegistor
    {
        private readonly IConfiguration _configuration;
        private readonly IHostApplicationLifetime _lifetime;
        private readonly IConsulClient _client;
        private readonly ILogger<ConsulServiceRegistor> _logger;
        private readonly IServiceEndpointsGetter _endpointsGetter;
        private readonly IHostEnvironment _environment;

        public ConsulServiceRegistor(
            IConfiguration configuration,
            IHostApplicationLifetime lifetime,
            IConsulClient client,
            ILogger<ConsulServiceRegistor> logger,
            IServiceEndpointsGetter endpointsGetter,
            IHostEnvironment environment)
        {
            _configuration = configuration;
            _lifetime = lifetime;
            _client = client;
            _logger = logger;
            _endpointsGetter = endpointsGetter;
            _environment = environment;
        }
        
        public async Task RegisterServiceAsync()
        {
            if (string.IsNullOrWhiteSpace(_configuration["ServiceDiscoveryOptions:ServiceName"])
                || string.IsNullOrWhiteSpace(_configuration["ServiceDiscoveryOptions:ModuleName"]))
            {
                throw new ArgumentException("Service Name must be configured", _configuration["ServiceDiscoveryOptions:ServiceName"]);
            }

            var endpoints = await _endpointsGetter.GetLocalServiceEndpointsAsync();

            foreach (var endpoint in endpoints)
            {
                var url = new Uri(endpoint);
                var serviceId = 
                    $"{_configuration["ServiceDiscoveryOptions:ModuleName"]}_{_configuration["ServiceDiscoveryOptions:ServiceName"]}_{url.Host}:{url.Port}";
                
                _logger.LogInformation($"Registering service {serviceId} for address {url}.");
                
                var serviceCheck =  new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(15),
                    Interval = TimeSpan.FromSeconds(30),
                    HTTP = new Uri(url, _configuration["ServiceDiscoveryOptions:HealthCheckTemplate"]).OriginalString
                };
                if (_environment.IsDevelopment())
                {
                    serviceCheck.DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(30);
                    serviceCheck.Interval = TimeSpan.FromSeconds(30);
                }
                
                var registation = new AgentServiceRegistration
                {
                    Check = serviceCheck,
                    Address = url.Host,
                    ID = serviceId,
                    Name = $"{_configuration["ServiceDiscoveryOptions:ModuleName"]}.{_configuration["ServiceDiscoveryOptions:ServiceName"]}",
                    Port = url.Port
                };

                await _client.Agent.ServiceRegister(registation);
                _lifetime.ApplicationStopping.Register(() =>
                {
                    _client.Agent.ServiceDeregister(registation.ID).GetAwaiter().GetResult();
                });
            }
        }
    }
}