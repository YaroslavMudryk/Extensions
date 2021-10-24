using Extensions.Repository.Models;

namespace Extensions.Repository
{
    public static class PagedListExtensions
    {
        public static Pagination ToPagination<TEntity>(this PagedList<TEntity> pagedList)
        {
            return new Pagination(pagedList.Total, pagedList.Count, pagedList.PerPage, pagedList.CurrentPage, pagedList.TotalPages);
        }
    }
}