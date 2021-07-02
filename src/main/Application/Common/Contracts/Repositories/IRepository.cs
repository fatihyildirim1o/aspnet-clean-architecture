using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Common.Enums;
using Domain.Common;

namespace Application.Common.Contracts.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<ICollection<T>> GetListAsync(
            Expression<Func<T, bool>> predicate = null,
            int? skip = null,
            int? take = null,
            Tuple<Expression<Func<T, object>>, OrderBy> orderBy = null,
            params Expression<Func<T, object>>[] includes
        );
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
    }
}
