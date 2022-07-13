using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using NorthwindLibrary;
using NorthwindLibrary.Entities;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ICategoryService _categoryService;
    private IProductService _productService;

    public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductService productService)
    {
        _logger = logger;
        _categoryService = categoryService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProducts();
        var categories = await _categoryService.GetAllCategories();
        var model = new CategoryProductViewModel
        {
            Products = products,
            Categories = categories
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
