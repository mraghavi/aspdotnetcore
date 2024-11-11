using Microsoft.AspNetCore.Mvc;

using EcommerceApp.Models;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost("order")]
        public IActionResult CreateOrder([FromForm] Order order)
        {
            // Check for model validation errors
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();
                return BadRequest(new { Errors = errors });
            }

            // Calculate the total price of the products
            double calculatedTotal = order.Products.Sum(p => p.Price * p.Quantity);

            // Validate that the InvoicePrice matches the calculated total
            if (calculatedTotal != order.InvoicePrice)
            {
                return BadRequest(new { Error = "InvoicePrice doesn't match the total cost of the specified products in the order" });
            }

            // Generate the Order Number (Random between 1 and 99999)
            Random random = new Random();
            order.OrderNo = random.Next(1, 99999);

            // Return the newly generated order number with success message
            return Ok(new { Message = $"New Order Number: {order.OrderNo}" });
        }
    }
}
