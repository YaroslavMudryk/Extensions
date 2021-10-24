﻿using Extensions.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Extensions.Repository
{
    public class AsyncCRUDRepository<TEntity> : IAsyncCRUDRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public AsyncCRUDRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region Writable

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> RemoveAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        #endregion

        #region Readable

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

        public async Task<IPagedList<TEntity>> GetPagedListAsync<TKey>(Expression<Func<TEntity, bool>> predicate = null, int page = 1, int countPerPage = 20, Expression<Func<TEntity, TKey>> orderBy = null, OrderType orderType = OrderType.Ascending)
        {
            var totalCount = await CountAsync(predicate);
            int skip = 0;
            if (totalCount < countPerPage)
            {
                countPerPage = totalCount;
                skip = 0;
            }
            else
                skip = page > 1 ? (page - 1) * countPerPage : 0;
            IQueryable<TEntity> _items = _dbSet.AsNoTracking();
            if (predicate != null)
                _items = _items.Where(predicate);
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

        #endregion

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
    }
}