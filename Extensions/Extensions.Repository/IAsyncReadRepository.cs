using Extensions.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Extensions.Repository
{
    public interface IAsyncReadRepository<TEntity> : IAsyncDisposable where TEntity: class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IPagedList<TEntity>> GetPagedListAsync<TKey>(int page = 1, int countPerPage = 20, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, TKey>> orderBy = null, OrderType orderType = OrderType.Ascending);
        Task<IPagedList<TEntity>> GetPagedListAsync<TKey>(int page = 1, int countPerPage = 20, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, TKey>> orderBy = null, OrderType orderType = OrderType.Ascending, Expression<Func<TEntity, TKey>> include = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}