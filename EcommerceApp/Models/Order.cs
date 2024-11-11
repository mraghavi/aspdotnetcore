using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.ComponentModel.DataAnnotations;
using EcommerceApp.Validators;

namespace EcommerceApp.Models
{
    public class Order
    {
        [BindNever] // Prevent OrderNo from being bound by the user input
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "OrderDate can't be blank")]
        [DataType(DataType.DateTime)]
        [CustomOrderDate] // Apply custom date validation
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "InvoicePrice is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "InvoicePrice must be greater than zero")]
        public double InvoicePrice { get; set; }

        [Required(ErrorMessage = "At least one product is required")]
        [MinLength(1, ErrorMessage = "At least one product must be provided")]
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        [Required(ErrorMessage = "ProductCode is required")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
