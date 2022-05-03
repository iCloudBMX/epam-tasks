using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Core.Models;

namespace WebApi.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProductsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducts() =>
            Ok(applicationDbContext.Products
                .Include(product => product.Category));

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id) =>
            Ok(applicationDbContext.Products
                .Include(product => product.Category)
                .FirstOrDefaultAsync(product => product.Id == id));

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            applicationDbContext.Products.Add(product);
            applicationDbContext.SaveChanges();
            return Created("", product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            var productToUpdate = applicationDbContext.Products.Find(id);
            
            if (productToUpdate == null)
                return NotFound();
            
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Category = product.Category;
            
            applicationDbContext.SaveChanges();
            
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var productToDelete = applicationDbContext.Products.Find(id);

            if (productToDelete == null)
                return NotFound();

            applicationDbContext.Products.Remove(productToDelete);
            applicationDbContext.SaveChanges();

            return NoContent();
        }
    }
}
