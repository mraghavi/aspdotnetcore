using ProductMockAPI.Models;

namespace ProductMockAPI.Data
{
    public class ProductData
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Description = "A high-end laptop" },
            new Product { Id = 2, Name = "Smartphone", Price = 700, Description = "A flagship smartphone" },
            new Product { Id = 3, Name = "Headphones", Price = 150, Description = "Noise-cancelling headphones" }
        };
    }
}
