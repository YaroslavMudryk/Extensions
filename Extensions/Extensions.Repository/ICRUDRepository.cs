namespace Extensions.Repository
{
    public interface IAsyncCRUDRepository<TEntity> : IAsyncReadRepository<TEntity>, IAsyncWriteRepository<TEntity> where TEntity : class
    {

    }
}