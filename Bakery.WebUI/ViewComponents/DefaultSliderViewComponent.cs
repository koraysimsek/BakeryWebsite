using Bakery.WebUI.Dtos.Chefs;
using Bakery.WebUI.Dtos.Sliders;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bakery.WebUI.ViewComponents
{
    public class DefaultSliderViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultSliderViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
