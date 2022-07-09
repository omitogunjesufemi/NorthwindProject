using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetByOrderID(int id);
        Task<bool> DeleteByOrderID(int id);
    }
}