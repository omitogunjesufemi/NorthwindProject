using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        Task<IList<OrderDetail>> GetOrderDetailByOrderID(int orderID);
        Task<IList<OrderDetail>> GetOrderDetailByProductID(int productID);
        Task<bool> DeleteOrderDetailByOrderID(int orderID);
        Task<bool> DeleteOrderDetailByProductID(int productID);
    }
}