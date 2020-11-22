using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DBTools.EntityFramework.Abstract.Interfaces;
using DBTools.EntityFramework.Tools;
using SeedWork.ErrorCode;
using SeedWork.Models.Message;

namespace DBTools.EntityFramework.Models
{
    public static class PagedCollectionBuilder
    {
        public static async Task<MessagePagedCollection<T>> BuildPagedMessageAsync<T>(
            IOrderedQueryable<T> query,
            IPageable pager,
            ErrorType code,
            string message)
        {
            var items = await BuildPagedAsync(query, pager);
            return new MessagePagedCollection<T>(items)
            {
                TotalCount = await query.CountAsync(),
                CurrentPage = pager.PageNumber,
                CurrentPageSize = pager.PageSize,
                Code = code,
                Message = message
            };
        }
        
        public static async Task<List<T>> BuildPagedAsync<T>(
            IOrderedQueryable<T> query,
            IPageable pager)
        {
            var items = await query.Page(pager).ToListAsync();
            return items;
        }
    }
}
