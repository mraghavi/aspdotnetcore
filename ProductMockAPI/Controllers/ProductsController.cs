using Microsoft.AspNetCore.Mvc;
using ProductMockAPI.Data;
using ProductMockAPI.Models;

namespace ProductMockAPI.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            // GET: api/products
            [HttpGet]
            public ActionResult<IEnumerable<Product>> GetAllProducts()
            {
                return Ok(ProductData.Products);
            }

            // GET: api/products/{id}
            [HttpGet("{id}")]
            public ActionResult<Product> GetProductById(int id)
            {
                var product = ProductData.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                return Ok(product);
            }

            // POST: api/products
            [HttpPost]
            public ActionResult<Product> AddProduct([FromBody] Product newProduct)
            {
                if (newProduct == null)
                {
                    return BadRequest("Product is null.");
                }
                newProduct.Id = ProductData.Products.Max(p => p.Id) + 1; 
                ProductData.Products.Add(newProduct);
                return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
            }

            // PUT: api/products/{id}
            [HttpPut("{id}")]
            public ActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
            {
                var product = ProductData.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                product.Description = updatedProduct.Description;
                return NoContent(); // HTTP 204
            }

            // DELETE: api/products/{id}
            [HttpDelete("{id}")]
            public ActionResult DeleteProduct(int id)
            {
                var product = ProductData.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                ProductData.Products.Remove(product);
                return NoContent();
            }
        }
}
