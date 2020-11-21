using System.Threading;
using System.Threading.Tasks;

namespace DBTools.EntityFramework.Abstract.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}