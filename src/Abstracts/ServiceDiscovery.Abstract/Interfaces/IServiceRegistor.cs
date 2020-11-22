using System.Threading.Tasks;

namespace ServiceDiscovery.Abstract.Interfaces
{
    public interface IServiceRegistor
    {
        Task RegisterServiceAsync();
    }
}