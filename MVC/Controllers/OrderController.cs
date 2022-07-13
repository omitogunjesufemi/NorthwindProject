using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using NorthwindLibrary;
using NorthwindLibrary.Entities;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task<IActionResult> GetAllOrders()
        {
            var model = await _orderService.GetAllOrders();
            return View(model);
        }

        public async Task<IActionResult> OrderCart(int id)
        {
            var order = await _orderService.GetOrder(id);
            var customer = await _customerService.GetCustomer(order.CustomerID);
            var model = new CartOrderViewModel
            {
                Customer = customer,
                Order = order
            };
            return View(model);
        }
    }
}
