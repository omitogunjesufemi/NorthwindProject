using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IProductRepository : IBaseRepository<Product, NorthwindDbContext>
    {
        Task<Product> GetByProductID(int id);
        Task<bool> DeleteByProductID(int id);
    }
}