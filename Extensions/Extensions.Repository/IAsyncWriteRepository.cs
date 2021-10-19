using System.Threading.Tasks;

namespace Extensions.Repository
{
    public interface IAsyncWriteRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(params TEntity[] entities);
        Task UpdateAsync(params TEntity[] entities);
        Task RemoveAsync(params TEntity[] entities);
    }
}
