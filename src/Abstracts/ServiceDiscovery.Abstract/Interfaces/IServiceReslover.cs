using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDiscovery.Abstract.Interfaces
{
    public interface IServiceReslover
    {
        Task<List<string>> ResloveServiceAsync(string moduleName, string serviceName);
    }
}