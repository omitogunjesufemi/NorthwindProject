using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class CategoryService : ICategoryService
    {
        protected CategoryRepository repository;
        public CategoryService(CategoryRepository _repository)
        {
            repository = _repository;
        }

        public Task<IList<Category>> GetAllCategories()
        {
            var categories = repository.GetAllAsync();
            return categories;
        }

        public Task<Category> GetCategory(int id)
        {
            var category = repository.GetByCategoryID(id);
            return category;
        }

        public Task<Category> GetCategory(string categoryName)
        {
            var category = repository.GetByCategoryName(categoryName);
            return category;
        }

        public Task<Category> CreateCategory(Category category)
        {
            var newCategory = repository.CreateAsync(category);
            return newCategory;
        }

        public Task<Category> UpdateCategory(Category category)
        {
            var updatedCategory = repository.UpdateAsync(category);
            return updatedCategory;
        }

        public Task<bool> DeleteCategory(int id)
        {
            var deleteStatus = repository.DeleteByCategoryID(id);
            return deleteStatus;
        }
    }
}
    