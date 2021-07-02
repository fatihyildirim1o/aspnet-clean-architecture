using Application.Common.Enums;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.ObjectRelationMapping.EntityFramework.Config
{
    public class EfEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        public EfEntityRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = _dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            var addedEntity = _dbContext.Entry(entities);
            addedEntity.State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            int? skip = null,
            int? take = null,
            Tuple<Expression<Func<TEntity, object>>, OrderBy> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes
            )
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            if (skip != null)
                query = query.Skip((int)skip);

            if (take != null)
                query = query.Take((int)take);

            if (orderBy?.Item1 != null && orderBy.Item2 == OrderBy.Asc)
                query = query.OrderBy(orderBy.Item1);

            if (orderBy?.Item1 != null && orderBy.Item2 == OrderBy.Desc)
                query = query.OrderByDescending(orderBy.Item1);

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            var deletedEntity = _dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(ICollection<TEntity> entities)
        {
            var addedEntity = _dbContext.Entry(entities);
            addedEntity.State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }


        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? await _dbContext.Set<TEntity>().CountAsync()
                : await _dbContext.Set<TEntity>().CountAsync(filter);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var updatedEntity = _dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(ICollection<TEntity> entities)
        {
            var updatedEntity = _dbContext.Entry(entities);
            updatedEntity.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
