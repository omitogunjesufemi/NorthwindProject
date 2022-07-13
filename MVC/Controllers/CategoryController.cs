using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using NorthwindLibrary;
using NorthwindLibrary.Entities;

namespace MVC.Controllers
{
    public class CategoryController:Controller
    {
        private ILogger<CategoryController> _logger;
        private ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CategoryDetails(int id)
        {
            var model = await _categoryService.GetCategory(id);
            return View(model);
        }
    }
}
