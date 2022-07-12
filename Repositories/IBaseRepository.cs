using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IBaseRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
         Task<IList<TEntity>> GetAllAsync();
         Task<TEntity> CreateAsync(TEntity entity);
         Task<TEntity> UpdateAsync(TEntity entity);
    }
}