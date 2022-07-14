using NorthwindLibrary.Entities;
using System.Collections.Generic;

namespace MVC.Models
{
    public class CartOrderViewModel
    {
        public Order Order { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public IList<Supplier> Supplier { get; set; }
    }
}
