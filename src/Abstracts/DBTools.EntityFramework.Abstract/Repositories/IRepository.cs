using System;
using System.Linq;
using System.Threading.Tasks;
using DBTools.EntityFramework.Abstract.UnitOfWork;

namespace DBTools.EntityFramework.Abstract.Repositories
{
    public abstract class IRepository<TEntity> where TEntity : class
    {
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public abstract Task<int> CommitAsync();
    }
}