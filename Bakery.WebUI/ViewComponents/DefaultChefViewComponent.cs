using Bakery.WebUI.Dtos.Chefs;
using Bakery.WebUI.Dtos.Sliders;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bakery.WebUI.ViewComponents
{
    public class DefaultChefViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultChefViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Chef");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsondata);

                return View(values);
            }
            return View();
        }
    }
}
