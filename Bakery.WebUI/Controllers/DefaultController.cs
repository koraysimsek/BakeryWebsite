using Bakery.WebUI.Dtos.Subscribes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Bakery.WebUI.Controllers
{
    [Route("Default")]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Subscribe")]
        public async Task<IActionResult> Subscribe(CreateSubscribeDto createSubscribeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Subscribe", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Abonelik işleminiz başarıyla gerçekleştirildi." });
            }
            return Json(new { success = false, message = "Bir hata oluştu. Lütfen tekrar deneyin." });
        }
    }
}
