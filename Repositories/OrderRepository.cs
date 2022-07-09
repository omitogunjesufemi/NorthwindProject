using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class OrderRepository : BaseRepository<Order, NorthwindDbContext>, IOrderRepository
    {
        protected NorthwindDbContext context;

        public OrderRepository(NorthwindDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<Order> GetByOrderID(int id)
        {
            Order order = await context.Orders.FindAsync(id);
            return order;
        }

        public async Task<bool> DeleteByOrderID(int id)
        {
            Order order = await context.Orders.FindAsync(id);
            context.Remove(order);
            await context.SaveChangesAsync();
            return true;
        }

    }
}