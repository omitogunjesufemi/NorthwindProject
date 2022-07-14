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
        private readonly IEmployeeService _employeeService;
        private readonly ISupplierService _supplierService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService, ICustomerService customerService, IEmployeeService employeeService, ISupplierService supplierService, IOrderDetailService orderDetailService)
        {
            _logger = logger;
            _orderService = orderService;
            _customerService = customerService;
            _employeeService = employeeService;
            _supplierService = supplierService;
            _orderDetailService = orderDetailService;
        }

        public async Task<IActionResult> GetAllOrders()
        {
            var model = await _orderService.GetAllOrders();
            return View(model);
        }

        public async Task<IActionResult> OrderProfile(int id)
        {
            var order = await _orderService.GetOrder(id);
            var customerID = order.CustomerID;
            Customer customer = await _customerService.GetCustomer(customerID);
            Employee employee = await _employeeService.GetEmployee(order.EmployeeID);
            IList<OrderDetail> orderDetails = await _orderDetailService.GetAllOrderDetails(order.OrderID);
            IList<Supplier> supplier = await _supplierService.GetAllSuppliers();
            
            var model = new CartOrderViewModel
            {
                Customer = customer,
                Order = order,
                Employee = employee,
                OrderDetails = orderDetails,
                Supplier = supplier
            };
            return View(model);
        }
    }
}
