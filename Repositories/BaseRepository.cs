using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace NorthwindLibrary
{
    public class BaseRepository<TEntity, TContext>:IBaseRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        private TContext _context;

        public BaseRepository(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToList();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            await _context.Set<TEntity>().Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();            
            return entity;
        }
    }
}