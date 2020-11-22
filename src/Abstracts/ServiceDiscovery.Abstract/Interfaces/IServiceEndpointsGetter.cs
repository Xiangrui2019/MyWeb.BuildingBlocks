using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDiscovery.Abstract.Interfaces
{
    public interface IServiceEndpointsGetter
    {
        Task<List<string>> GetLocalServiceEndpointsAsync();
    }
}