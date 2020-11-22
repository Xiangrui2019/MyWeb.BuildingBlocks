using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscovery.Services
{
    public class PodIpEndpointService : IServiceEndpointsGetter
    {
        public Task<List<string>> GetLocalServiceEndpointsAsync()
        {
            var ips = new List<string>();
            ips.Add(
                $"http://{Environment.GetEnvironmentVariable("POD_IP")}:80");
            
            return Task.FromResult(ips);
        }
    }
}