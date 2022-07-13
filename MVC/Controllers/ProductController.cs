using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using NorthwindLibrary;
using NorthwindLibrary.Entities;

namespace MVC.Controllers
{
    public class ProductController:Controller
    {
        private readonly ILogger<ProductController> _logger;
        private IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var model = await _productService.GetProduct(id);
            return View(model);
        }
    }
}