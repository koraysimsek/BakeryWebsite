using Bakery.WebApi.Context;
using Bakery.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly BakeryContext _context;

        public AboutController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListAbout()
        {
            var values = _context.Abouts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var values = _context.Abouts.Find(id);

            _context.Abouts.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }
    }
}
