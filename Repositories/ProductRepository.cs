using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class ProductRepository : BaseRepository<Product, NorthwindDbContext>, IProductRepository 
    {
        protected NorthwindDbContext context;
        public ProductRepository(NorthwindDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<Product> GetByProductID(int id)
        {
            Product product = await context.Products.FindAsync(id);
            return product;
        }

        public async Task<bool> DeleteByProductID(int id)
        {
            Product product = await context.Products.FindAsync(id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return true;
        }

    }
}