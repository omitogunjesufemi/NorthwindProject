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
            IList<OrderDetail> orderDetail = await context.OrderDetails.ToListAsync();
            return orderDetail;
        }

        public async Task<IList<OrderDetail>> GetOrderDetailByProductID(int productID)
        {
            IList<OrderDetail> orderDetail = await context.OrderDetails.ToListAsync();
            return orderDetail;
        }
        public async Task<bool> DeleteOrderDetailByOrderID(int orderID)
        {
            return true;
        }
        public async Task<bool> DeleteOrderDetailByProductID(int productID)
        {
            return true;
        }
    }
}