using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IOrderService
    {
        Task<IList<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
