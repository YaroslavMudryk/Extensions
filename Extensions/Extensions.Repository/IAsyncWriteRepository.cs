using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Extensions.Repository
{
    public interface IAsyncWriteRepository<TEntity> : IAsyncDisposable where TEntity : class
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task<IEnumerable<TEntity>> RemoveAsync(IEnumerable<TEntity> entities);
    }
}