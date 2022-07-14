using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail, NorthwindDbContext>
    {
        Task<IList<OrderDetail>> GetOrderDetailByOrderID(int orderID);
        Task<IList<OrderDetail>> GetOrderDetailByProductID(int productID, int orderID);
        Task<bool> DeleteOrderDetailByOrderID(int orderID);
        Task<bool> DeleteAllOrderDetailsForAProductID(int productID, int orderID);
    }
}