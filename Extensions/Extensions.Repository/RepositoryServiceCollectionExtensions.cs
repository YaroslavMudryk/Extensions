using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Extensions.Repository
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static void AddRepositories<TContext>(this IServiceCollection services) where TContext: DbContext
        {
            services.AddScoped<DbContext, TContext>();
            services.AddScoped(typeof(IAsyncReadRepository<>), typeof(AsyncReadRepository<>));
            services.AddScoped(typeof(IAsyncWriteRepository<>), typeof(AsyncWriteRepository<>));
        }
    }
}