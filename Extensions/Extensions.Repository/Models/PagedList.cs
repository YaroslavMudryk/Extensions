using System;
using System.Collections.Generic;
using System.Linq;
namespace Extensions.Repository.Models
{
    public class PagedList<TEntity> : IPagedList<TEntity>
    {
        public IEnumerable<TEntity> Items { get; }
        public int Total { get; }
        public int Count { get; }
        public int PerPage { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public PagedList(IEnumerable<TEntity> items, int total, int page, int perPage = 20)
        {
            Items = items;
            Total = total;
            Count = Items.Count();
            PerPage = perPage;
            CurrentPage = page;
            TotalPages = (int)Math.Ceiling(total / (double)perPage);
        }
    }
}