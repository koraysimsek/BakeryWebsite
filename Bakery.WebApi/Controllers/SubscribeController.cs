using Bakery.WebApi.Context;
using Bakery.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly BakeryContext _context;

        public SubscribeController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListSubscribe()
        {
            var values = _context.Subscribes.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subscribe = _context.Subscribes.Find(id);
            return Ok(subscribe);
        }


        [HttpPost]
        public IActionResult CreateSubscribe(Subscribe subscribe)
        {
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribes)
        {
            _context.Subscribes.Update(subscribes);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _context.Subscribes.Find(id);

            _context.Subscribes.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }

        [HttpGet("CountSubscribe")]
        public IActionResult GetSubscribe()
        {
            var subscribeCount = _context.Subscribes.Count();
            return Ok(subscribeCount);
        }
    }
}
