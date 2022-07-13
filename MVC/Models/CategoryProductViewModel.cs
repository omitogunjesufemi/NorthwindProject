using NorthwindLibrary.Entities;
using System.Collections.Generic;

namespace MVC.Models
{
    public class CategoryProductViewModel
    {
        public IList<Product> Products { get; set; }
        public IList<Category> Categories { get; set; }

    }
}
