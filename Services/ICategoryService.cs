using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface ICategoryService
    {
         Task<IList<Category>> GetAllCategories();
         Task<Category> GetCategory(int id);
         Task<Category> GetCategory(string categoryName);
         Task<Category> CreateCategory(Category category);
         Task<Category> UpdateCategory(Category category);
         Task<bool> DeleteCategory(int id);
    }
}