using System;
using System.Linq;
using System.Threading.Tasks;
using DBTools.EntityFramework.Abstract.UnitOfWork;

namespace DBTools.EntityFramework.Abstract.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
        
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();
    }
}