using Extensions.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Extensions.Repository
{
    public partial class AsyncReadRepository<TEntity> : IAsyncReadRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public AsyncReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate is null)
                return await _dbSet.CountAsync();
            return await _dbSet.CountAsync(predicate);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate is null)
                return await _dbSet.AnyAsync();
            return await _dbSet.FirstOrDefaultAsync(predicate) is not null;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IPagedList<TEntity>> GetPagedListAsync<TKey>(Expression<Func<TEntity, bool>> predicate, int page = 1, int countPerPage = 20, Expression<Func<TEntity, TKey>> orderBy = null, OrderType orderType = OrderType.Ascending)
        {
            var totalCount = await CountAsync(predicate);

            int skip = 0;

            if (totalCount < countPerPage)
            {
                countPerPage = totalCount;
                skip = 0;
            }
            else
            {
                skip = page > 1 ? (page - 1) * countPerPage : 0;
            }

            IQueryable<TEntity> _items = _dbSet.AsNoTracking().Where(predicate);

            if (orderBy != null)
            {
                if (orderType == OrderType.Ascending)
                    _items = _items.OrderBy(orderBy);
                else
                    _items = _items.OrderByDescending(orderBy);
            }

            var items = await _items.Skip(skip).Take(countPerPage).ToListAsync();

            return new PagedList<TEntity>(items, totalCount, page, countPerPage);
        }
    }
}