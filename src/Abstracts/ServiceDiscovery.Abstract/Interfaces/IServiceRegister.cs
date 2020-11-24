using System.Threading.Tasks;

namespace ServiceDiscovery.Abstract.Interfaces
{
    public interface IServiceRegister
    {
        Task RegisterServiceAsync();
    }
}