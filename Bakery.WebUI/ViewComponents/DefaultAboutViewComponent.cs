using Bakery.WebUI.Dtos.Abouts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bakery.WebUI.ViewComponents
{
    public class DefaultAboutViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultAboutViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/About");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);

                return View(values);
            }
            return View();
        }
    }
}
