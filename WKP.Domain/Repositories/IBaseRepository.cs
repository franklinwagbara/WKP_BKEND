using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace WKP.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        Task<TEntity?>? GetAsync([AllowNull]object id);
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            IEnumerable<string>? includeProperties = null,
            int? take = null,
            int? skip = null);
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task DeleteAsync(TEntity entity);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);
        Task Update(TEntity entity);
    }
}