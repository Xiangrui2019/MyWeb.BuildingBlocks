using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscoveryWebApp.Mocks
{
    public class MockIP : IServiceEndpointsGetter
    {
        public Task<List<string>> GetLocalServiceEndpointsAsync()
        {
            var l = new List<string>();
            
            l.Add("http://localhost:15000");
            
            return Task.FromResult(l);
        }
    }
}