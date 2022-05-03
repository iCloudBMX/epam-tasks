using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Models;

namespace WebApi.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CategoriesController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Get() =>
            Ok(applicationDbContext.Categories);

        [HttpGet("{id}")]
        public IActionResult Get(int id) =>
            Ok(applicationDbContext.Categories.Find(id));

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            applicationDbContext.Categories.Add(category);
            applicationDbContext.SaveChanges();
            
            return Created("", category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var categoryToUpdate = applicationDbContext.Categories.Find(id);
            
            if (categoryToUpdate == null)
                return NotFound();
            
            categoryToUpdate.Name = category.Name;
            
            applicationDbContext.SaveChanges();
            
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoryToDelete = applicationDbContext.Categories.Find(id);
            
            if (categoryToDelete == null)
                return NotFound();
            
            applicationDbContext.Categories.Remove(categoryToDelete);
            applicationDbContext.SaveChanges();
            
            return Ok(categoryToDelete);
        }
    }
}
