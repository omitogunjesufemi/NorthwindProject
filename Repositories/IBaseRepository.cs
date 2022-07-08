using System.Threading.Tasks;
using System.Collections.Generic;
namespace NorthwindLibrary
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
         Task<IList<TEntity>> GetAllAsync();
         Task<TEntity> CreateAsync(TEntity entity);
         Task<TEntity> UpdateAsync(TEntity entity);
    }
}