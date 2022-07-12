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

    public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var model = _categoryService.GetAllCategories();
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
