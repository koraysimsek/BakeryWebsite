using Bakery.WebUI.Dtos.Sliders;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bakery.WebUI.ViewComponents
{
    public class DefaultStatisticViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultStatisticViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Product/CountProduct");
            var jsonData = await response.Content.ReadAsStringAsync();

            ViewBag.ProductCount = jsonData;

            var response1 = await client.GetAsync("https://localhost:7210/api/Chef/CountChef");
            var jsonData1 = await response1.Content.ReadAsStringAsync();

            ViewBag.ChefCount = jsonData1;

            var response2 = await client.GetAsync("https://localhost:7210/api/Service/CountService");
            var jsonData2 = await response2.Content.ReadAsStringAsync();

            ViewBag.ServiceCount = jsonData2;

            return View();
        }
    }
}
