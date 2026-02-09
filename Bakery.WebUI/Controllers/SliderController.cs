using Bakery.WebUI.Dtos.Sliders;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Bakery.WebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ListSlider()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Slider");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsondata);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Slider", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListSlider");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Slider/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7210/api/Slider/", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListSlider");
            }

            return View();
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            var client = _httpClientFactory.CreateClient();

            await client.DeleteAsync($"https://localhost:7210/api/Slider?id={id}");

            return RedirectToAction("ListSlider");
        }
    }
}
