using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class ShipperRepository : BaseRepository<Shipper, NorthwindDbContext>, IShipperRepository
    {
        protected NorthwindDbContext context;
        public ShipperRepository(NorthwindDbContext _context):base(_context)
        {
            context = _context; 
        }

        public async Task<Shipper> GetByShipperID(int id)
        {
            Shipper shipper = await context.Shippers.FindAsync(id);
            return shipper;
        }

        public async Task<bool> DeleteByShipperID(int id)
        {
            Shipper shipper = await context.Shippers.FindAsync(id);
            context.Shippers.Remove(shipper);
            await context.SaveChangesAsync();
            return true;
        }
    }
}