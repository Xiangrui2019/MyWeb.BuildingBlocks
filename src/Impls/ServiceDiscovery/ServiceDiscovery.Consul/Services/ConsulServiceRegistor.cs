using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceDiscovery.Abstract.Interfaces;
using ServiceDiscovery.Consul.Models;

namespace ServiceDiscovery.Consul.Services
{
    public class ConsulServiceRegistor : IServiceRegistor
    {
        private readonly IOptions<ServiceDiscoveryOptions> _discoveryOptions;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IHostApplicationLifetime _lifetime;
        private readonly IConsulClient _client;
        private readonly ILogger<ConsulServiceRegistor> _logger;
        private readonly IServiceEndpointsGetter _endpointsGetter;
        private readonly IHostEnvironment _environment;

        public ConsulServiceRegistor(
            IOptions<ServiceDiscoveryOptions> discoveryOptions,
            ILoggerFactory loggerFactory,
            IHostApplicationLifetime lifetime,
            IConsulClient client,
            ILogger<ConsulServiceRegistor> logger,
            IServiceEndpointsGetter endpointsGetter,
            IHostEnvironment environment)
        {
            _discoveryOptions = discoveryOptions;
            _loggerFactory = loggerFactory;
            _lifetime = lifetime;
            _client = client;
            _logger = logger;
            _endpointsGetter = endpointsGetter;
            _environment = environment;
        }
        
        public async Task RegisterServiceAsync()
        {
            if (string.IsNullOrWhiteSpace(_discoveryOptions.Value.ModuleName)
                || string.IsNullOrWhiteSpace(_discoveryOptions.Value.ServiceName))
            {
                throw new ArgumentException("Service Name must be configured", _discoveryOptions.Value.ServiceName);
            }

            var endpoints = await _endpointsGetter.GetLocalServiceEndpointsAsync();

            foreach (var endpoint in endpoints)
            {
                var url = new Uri(endpoint);
                var serviceId = 
                    $"{_discoveryOptions.Value.ModuleName}_{_discoveryOptions.Value.ServiceName}_{url.Host}:{url.Port}";
                
                _logger.LogInformation($"Registering service {serviceId} for address {url}.");
                
                var serviceCheck =  new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(1),
                    Interval = TimeSpan.FromSeconds(30),
                    HTTP = new Uri(url, _discoveryOptions.Value.HealthCheckTemplate).OriginalString
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
                    Name = $"{_discoveryOptions.Value.ModuleName}.{_discoveryOptions.Value.ServiceName}",
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