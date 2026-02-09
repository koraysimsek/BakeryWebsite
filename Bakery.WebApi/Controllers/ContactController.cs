using Bakery.WebApi.Context;
using Bakery.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly BakeryContext _context;

        public ContactController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListContact()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _context.Contacts.Find(id);

            _context.Contacts.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }
    }
}
