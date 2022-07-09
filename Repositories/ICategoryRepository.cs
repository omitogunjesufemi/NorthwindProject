using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetByCategoryID(int id);
        Task<Category> GetByCategoryName(string categoryName);
        Task<bool> DeleteByCategoryID(int id);
    }
}