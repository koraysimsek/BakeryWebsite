using Bakery.WebApi.Context;
using Bakery.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly BakeryContext _context;

        public TestimonialController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListTestimonial()
        {
            var values = _context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            return Ok(testimonial);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _context.Testimonials.Find(id);

            _context.Testimonials.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }

        [HttpGet("CountTestimonial")]
        public IActionResult GetTestimonial()
        {
            var testimonialCount = _context.Testimonials.Count();
            return Ok(testimonialCount);
        }

        [HttpGet("LastTestimonial")]
        public IActionResult GetLastTestimonial()
        {
            var testimonialLast = _context.Testimonials
                                      .OrderByDescending(x => x.TestimonialId)
                                      .Select(x => x.NameSurname)
                                      .FirstOrDefault();

            return Ok(testimonialLast);
        }
    }
}
