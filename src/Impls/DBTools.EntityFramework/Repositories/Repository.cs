using System;
using System.Threading.Tasks;
using DBTools.EntityFramework.Abstract.Repositories;
using DBTools.EntityFramework.Abstract.UnitOfWork;

namespace DBTools.EntityFramework.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; }
        
        public Task<int> CommitAsync()
        {
            return UnitOfWork.SaveChangesAsync();
        }
    }
}