using System.Net;

namespace ServiceDiscovery.Consul.Models
{
    public class ServiceDiscoveryOptions : Abstract.Models.ServiceDiscoveryOptions
    {
        public ConsulOptions Consul { get; set; }
    }
    
    public class ConsulOptions
    {
        public string HttpEndpoint { get; set; }

        public DnsEndpoint DnsEndpoint { get; set; }
    }

    public class DnsEndpoint
    {
        public string Address { get; set; }

        public int Port { get; set; }

        public IPEndPoint ToIPEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(Address), Port);
        }
    }
}