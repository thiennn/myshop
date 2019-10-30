using System.Collections.Generic;

namespace MyShop.Backend.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<ProductCategory> ProductCategories { get; private set; } = new List<ProductCategory>();
    }
}
