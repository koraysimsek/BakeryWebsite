using Bakery.WebUI.Dtos.Categories;
using Bakery.WebUI.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bakery.WebUI.ViewComponents
{
    public class DefaultProductViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultProductViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Product");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductWithCategoryDto>>(jsondata);

                return View(values);
            }
            return View();
        }
    }
}
