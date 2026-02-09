using Bakery.WebApi.Context;
using Bakery.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly BakeryContext _context;

        public ChefController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListChef()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var chef = _context.Chefs.Find(id);
            return Ok(chef);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var values = _context.Chefs.Find(id);

            _context.Chefs.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }

        [HttpGet("CountChef")]
        public IActionResult GetChef()
        {
            var productChef = _context.Chefs.Count();
            return Ok(productChef);
        }

    }
}
