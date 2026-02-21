using Bakery.WebApi.Context;
using Bakery.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly BakeryContext _context;

        public ServiceController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListService()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var service = _context.Services.Find(id);
            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var values = _context.Services.Find(id);

            _context.Services.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }

        [HttpGet("CountService")]
        public IActionResult GetService()
        {
            var serviceCount = _context.Services.Count();
            return Ok(serviceCount);
        }

        [HttpGet("LastService")]
        public IActionResult GetLastProduct()
        {
            var serviceLast = _context.Services
                                      .OrderByDescending(x => x.ServiceId)
                                      .Select(x => x.ServiceName)
                                      .FirstOrDefault();

            return Ok(serviceLast);
        }
    }
}
