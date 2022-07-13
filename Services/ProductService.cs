using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class ProductService : IProductService
    {
        protected ProductRepository repository;
        public ProductService(ProductRepository _repository)
        {
            repository = _repository;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var newProduct = await repository.CreateAsync(product);
            return newProduct;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var deleteStatus = await repository.DeleteByProductID(id);
            return deleteStatus;
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            var products = await repository.GetAllAsync();
            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await repository.GetByProductID(id);
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var updateProduct = await repository.UpdateAsync(product);
            return updateProduct;
        }
    }
}
