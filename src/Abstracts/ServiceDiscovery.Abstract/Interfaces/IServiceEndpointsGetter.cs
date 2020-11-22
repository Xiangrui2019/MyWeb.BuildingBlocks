using System.Threading.Tasks;

namespace ServiceDiscovery.Abstract.Interfaces
{
    public interface IServiceEndpointsGetter
    {
        Task<string> GetLocalServiceEndpoint();
    }
}