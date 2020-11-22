using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscovery.Services
{
    public class ConfigurationEndpointService : IServiceEndpointsGetter
    {
        private readonly IConfiguration _configuration;

        public ConfigurationEndpointService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public Task<List<string>> GetLocalServiceEndpointsAsync()
        {
            var ips = new List<string>();
            ips.Add(_configuration["ServiceDiscoveryOptions:ServiceEndpoint"]);
            
            return Task.FromResult(ips);
        }
    }
}