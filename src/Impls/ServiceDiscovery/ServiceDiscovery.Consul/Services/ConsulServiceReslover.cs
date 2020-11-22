using System.Collections.Generic;
using System.Threading.Tasks;
using DnsClient;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscovery.Consul.Services
{
    public class ConsulServiceReslover : IServiceReslover
    {
        private readonly IDnsQuery _dnsQuery;

        public ConsulServiceReslover(IDnsQuery dnsQuery)
        {
            _dnsQuery = dnsQuery;
        }
        
        public async Task<List<string>> ResloveServiceAsync(string moduleName, string serviceName)
        {
            var serviceQuery = $"{moduleName}.{serviceName}";
            var hosts = new List<string>();
            var hostEntries = await _dnsQuery.ResolveServiceAsync("service.consul", serviceQuery);
            
            foreach (var hostEntry in hostEntries)
            {
                hosts.Add($"http://{hostEntry.HostName}:{hostEntry.Port}/");
            }
            
            return hosts;
        }
    }
}