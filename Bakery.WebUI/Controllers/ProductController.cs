using Bakery.WebUI.Dtos.Categories;
using Bakery.WebUI.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Bakery.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ListProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Product/with-category");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductWithCategoryDto>>(jsondata);

                return View(values ?? new List<ProductWithCategoryDto>());
            }
            return View(new List<ProductWithCategoryDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();

            // API'den kategorileri çek
            var response = await client.GetAsync("https://localhost:7210/api/Category");
            var jsonData = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            ViewBag.Categories = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Product", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListProduct");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Ürünü çek
            var productResponse = await client.GetAsync("https://localhost:7210/api/Product/" + id);
            var productJson = await productResponse.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(productJson);

            // Kategorileri çek
            var categoryResponse = await client.GetAsync("https://localhost:7210/api/Category");
            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

            ViewBag.Categories = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7210/api/Product/", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListProduct");
            }

            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            await client.DeleteAsync($"https://localhost:7210/api/Product?id={id}");

            return RedirectToAction("ListProduct");
        }
    }
}
