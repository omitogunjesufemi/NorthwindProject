using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class OrderDetailRepository : BaseRepository<OrderDetail, NorthwindDbContext>, IOrderDetailRepository
    {
        protected NorthwindDbContext context;
        public OrderDetailRepository(NorthwindDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<IList<OrderDetail>> GetOrderDetailByOrderID(int orderID)
        {
            var orderDetails = await context.OrderDetails.Where(o => o.OrderID == orderID).ToListAsync();
            return orderDetails;
        }

        public async Task<IList<OrderDetail>> GetOrderDetailByProductID(int productID, int orderID)
        {
            var orderDetails = await context.OrderDetails.Where(o => o.ProductID == productID & o.OrderID == orderID).ToListAsync();
            return orderDetails;
        }

        public async Task<bool> DeleteOrderDetailByOrderID(int orderID)
        {
            var orderDetails = await GetOrderDetailByOrderID(orderID);
            context.RemoveRange(orderDetails);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllOrderDetailsForAProductID(int productID, int orderID)
        {
            var orderDetails = await GetOrderDetailByProductID(productID, orderID);
            context.RemoveRange(orderDetails);
            await context.SaveChangesAsync();            
            return true;
        }
    }
}