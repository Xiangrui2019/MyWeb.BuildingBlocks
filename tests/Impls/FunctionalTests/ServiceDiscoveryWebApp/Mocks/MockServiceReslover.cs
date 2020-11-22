using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceDiscovery.Abstract.Interfaces;

namespace ServiceDiscoveryWebApp.Mocks
{
    public class MockServiceReslover : IServiceReslover
    {
        public Task<List<string>> ResloveServiceAsync(string moduleName, string serviceName)
        {
            return Task.FromResult(new List<string>()
            {
                "A", "B", "C", "D", "E", "F", "G"
            });
        }
    }
}