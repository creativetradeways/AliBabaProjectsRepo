using Microsoft.AspNetCore.Mvc;
using Project1_withAliBaba.Models;

namespace Project1_withAliBaba.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 2500 },
            new Product { Id = 2, Name = "Mobile", Price = 1200 },
            new Product { Id = 3, Name = "TV", Price = 1200 }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = Products.Max(x => x.Id) + 1;

            Products.Add(product);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();

            Products.Remove(product);

            return NoContent();
        }
    }
}
