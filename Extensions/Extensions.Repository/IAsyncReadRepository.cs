using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Extensions.Repository
{
    public interface IAsyncReadRepository<TEntity> : IAsyncDisposable where TEntity: class
    {
        Task<List<TEntity>> GetAllAsync(bool disableTracking = true);
        Task<List<TEntity>> GetAllPagedAsync<TKey>(int count, int skip, Expression<Func<TEntity, TKey>> keySelector = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool disableTracking = true);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool disableTracking = true);
    }
}