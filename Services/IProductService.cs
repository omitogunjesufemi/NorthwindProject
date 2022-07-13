using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product> UpdateProduct(Product product);
    }
}
