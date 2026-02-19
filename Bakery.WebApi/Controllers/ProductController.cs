using Bakery.WebApi.Context;
using Bakery.WebApi.Dtos;
using Bakery.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly BakeryContext _context;

        public ProductController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet("with-category")]
        public IActionResult ListProduct()
        {
            var values = _context.Products.Include(p => p.Category).Select(p => new ProductWithCategoryDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                CategoryName = p.Category != null ? p.Category.CategoryName : null,
            });

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }

        [HttpGet("CountProduct")]
        public IActionResult GetProduct()
        {
            var productCount = _context.Products.Count();
            return Ok(productCount);
        }
    }
}
