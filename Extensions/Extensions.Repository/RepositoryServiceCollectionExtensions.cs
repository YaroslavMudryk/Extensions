using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Extensions.Repository
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static void AddRepositories<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddScoped<DbContext, TContext>();
            services.AddScoped(typeof(IAsyncReadRepository<>), typeof(AsyncReadRepository<>));
            services.AddScoped(typeof(IAsyncWriteRepository<>), typeof(AsyncWriteRepository<>));
            services.AddScoped(typeof(IAsyncCRUDRepository<>), typeof(AsyncCRUDRepository<>));
        }

        public static void AddRepositories<TContext1, TContext2>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
        {
            services.AddScoped<DbContext, TContext1>();
            services.AddScoped<DbContext, TContext2>();
            services.AddScoped(typeof(IAsyncReadRepository<>), typeof(AsyncReadRepository<>));
            services.AddScoped(typeof(IAsyncWriteRepository<>), typeof(AsyncWriteRepository<>));
            services.AddScoped(typeof(IAsyncCRUDRepository<>), typeof(AsyncCRUDRepository<>));
        }

        public static void AddRepositories<TContext1, TContext2, TContext3>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
            where TContext3 : DbContext
        {
            services.AddScoped<DbContext, TContext1>();
            services.AddScoped<DbContext, TContext2>();
            services.AddScoped<DbContext, TContext3>();
            services.AddScoped(typeof(IAsyncReadRepository<>), typeof(AsyncReadRepository<>));
            services.AddScoped(typeof(IAsyncWriteRepository<>), typeof(AsyncWriteRepository<>));
            services.AddScoped(typeof(IAsyncCRUDRepository<>), typeof(AsyncCRUDRepository<>));
        }

        public static void AddRepositories<TContext1, TContext2, TContext3, TContext4>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
            where TContext3 : DbContext
            where TContext4 : DbContext
        {
            services.AddScoped<DbContext, TContext1>();
            services.AddScoped<DbContext, TContext2>();
            services.AddScoped<DbContext, TContext3>();
            services.AddScoped<DbContext, TContext4>();
            services.AddScoped(typeof(IAsyncReadRepository<>), typeof(AsyncReadRepository<>));
            services.AddScoped(typeof(IAsyncWriteRepository<>), typeof(AsyncWriteRepository<>));
            services.AddScoped(typeof(IAsyncCRUDRepository<>), typeof(AsyncCRUDRepository<>));
        }
    }
}