using System.Collections.Generic;

namespace Extensions.Repository.Models
{
    public interface IPagedList<TEntity>
    {
        IEnumerable<TEntity> Items { get; }
        int Total { get; }
        int Count { get; }
        int PerPage { get; }
        int CurrentPage { get; }
        int TotalPages { get; }
    }
}