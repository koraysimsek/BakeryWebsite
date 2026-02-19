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
            var responseProduct = await client.GetAsync("https://localhost:7210/api/Product/with-category");
            var responseCategory = await client.GetAsync("https://localhost:7210/api/Category");

            if (responseProduct.IsSuccessStatusCode && responseCategory.IsSuccessStatusCode)
            {
                var jsonProduct = await responseProduct.Content.ReadAsStringAsync();
                var jsonCategory = await responseCategory.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<ProductWithCategoryDto>>(jsonProduct);
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategory);

                var model = new Models.ProductListViewModel
                {
                    Products = products,
                    Categories = categories
                };

                return View(model);
            }
            return View(new Models.ProductListViewModel());
        }
    }
}
