using System.Linq;
using DBTools.EntityFramework.Abstract.Interfaces;

namespace DBTools.EntityFramework.Tools
{
    public static class CollectionExtends
    {
        public static IQueryable<T> Page<T>(this IOrderedQueryable<T> query, IPageable pager)
        {
            return query
                .Skip((pager.PageNumber - 1) * pager.PageSize)
                .Take(pager.PageSize);
        }
    }
}