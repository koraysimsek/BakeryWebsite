using Bakery.WebUI.Dtos.Subscribes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace Bakery.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ListSubscribe()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Subscribe");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubscribeDto>>(jsondata);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateSubscribe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Subscribe", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListSubscribe");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Subscribe/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateSubscribeDto>(jsonData);

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscribe(UpdateSubscribeDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7210/api/Subscribe/", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListSubscribe");
            }

            return View();
        }
    }
}
