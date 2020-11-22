using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Consul;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscovery.Consul.Services
{
    public class ConsulServiceReslover : IServiceReslover, IDisposable
    {
        private readonly IConsulClient _client;
        private Dictionary<string, AgentService> _services;
        private readonly Timer _timer;

        public ConsulServiceReslover(IConsulClient client)
        {
            _client = client;
            SyncConsul(null, null);
            _timer = new Timer(10000);
            _timer.Elapsed += new ElapsedEventHandler(SyncConsul);
            _timer.Start();
        }

        private void SyncConsul(object source, System.Timers.ElapsedEventArgs e)
        {
            _services = _client.Agent.Services().Result.Response;
        }

        public Task<List<string>> ResloveServiceAsync(string moduleName, string serviceName)
        {
            var serviceQuery = $"{moduleName}.{serviceName}";
            var hosts = new List<string>();
            var hostEntries = _services
                .Where(s => 
                    s.Value.Service.Equals(
                        serviceQuery, StringComparison.CurrentCultureIgnoreCase))
                .Select(s => s.Value);

            foreach (var hostEntry in hostEntries)
            {
                hosts.Add($"http://{hostEntry.Address}:{hostEntry.Port}/");
            }
            
            return Task.FromResult(hosts);
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer?.Dispose();
        }
    }
}