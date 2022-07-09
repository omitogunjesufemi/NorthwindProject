using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class SupplierRepository :BaseRepository<Supplier, NorthwindDbContext>, ISupplierRepository
    {
        protected NorthwindDbContext context;

        public SupplierRepository(NorthwindDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<Supplier> GetBySupplierID(int id)
        {
            Supplier supplier = await context.Suppliers.FindAsync(id);
            return supplier;
        }

        public async Task<bool> DeleteBySupplierID(int id)
        {
            Supplier supplier = await context.Suppliers.FindAsync(id);
            context.Suppliers.Remove(supplier);
            await context.SaveChangesAsync();
            return true;
        }
    }
}