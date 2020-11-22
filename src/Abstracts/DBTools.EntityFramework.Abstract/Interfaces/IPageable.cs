using System.ComponentModel.DataAnnotations;

namespace DBTools.EntityFramework.Abstract.Interfaces
{
    public interface IPageable
    {
        [Range(1, int.MaxValue)]
        int PageNumber { get; set; }
        
        [Range(1, int.MaxValue)]
        int PageSize { get; set; }
    }
}