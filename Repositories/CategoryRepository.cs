using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class CategoryRepository : BaseRepository<Category, NorthwindDbContext>, ICategoryRepository
    {
        protected NorthwindDbContext context;
        public CategoryRepository(NorthwindDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<Category> GetByCategoryID(int id)
        {
            Category category = await context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryID == id);
            return category;
        }

        public async Task<Category> GetByCategoryName(string categoryName)
        {
            Category category = await context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            return category;
        }

        public async Task<bool> DeleteByCategoryID(int id)
        {
            Category category = await context.Categories.FindAsync(id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return true;
        }
    }
}