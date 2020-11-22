using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscovery.Abstract.Models
{
    public class ServiceDiscoveryOptions : IServiceDiscoveryOptions
    {
        public string ModuleName { get; set; }
        
        public string ServiceName { get; set; }

        public string HealthCheckTemplate { get; set; }
    }
}