using Bakery.WebApi.Context;
using Bakery.WebApi.Dtos;
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
                CategoryName = p.Category != null ? p.Category.CategoryName : null,
            });

            return Ok(values);
        }

        [HttpGet("CountProduct")]
        public IActionResult GetProduct()
        {
            var productCount = _context.Products.Count();
            return Ok(productCount);
        }
    }
}
