using Bakery.WebApi.Context;
using Bakery.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BakeryContext _context;

        public CategoryController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListCategory()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.Find(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var values = _context.Categories.Find(id);

            _context.Categories.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }

        [HttpGet("CountCategory")]
        public IActionResult GetCategory()
        {
            var categoryCount = _context.Categories.Count();
            return Ok(categoryCount);
        }
    }
}
