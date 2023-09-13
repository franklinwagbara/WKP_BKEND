using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly WKPContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(WKPContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        
        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task DeleteAsync(object id)
        {
            TEntity? entity = await _dbSet.FindAsync(id);
            
            if(entity is not null)  _dbSet.Remove(entity);
            
            return;
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = _dbSet.Where(filter);
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual async Task<TEntity?>? GetAsync([AllowNull] object id)
        {
            if(id is null) return null;
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            IEnumerable<string>? includeProperties = null,
            int? take = null,
            int? skip = null)
        {
            IQueryable<TEntity> query = _dbSet;
            
            if(includeProperties != null && includeProperties.Any())
            {
                foreach(var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            if(filter != null)
                query = query.Where(filter);

            if(orderBy != null)
                query = orderBy(query);

            if(take.HasValue)
                query = query.Take(take.Value);
            
            if(skip.HasValue)
                query = query.Skip(skip.Value);

            return await query.ToListAsync();
        }

        public virtual Task Update(TEntity entity)
        {
            if(_context.Entry(entity).State != EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}