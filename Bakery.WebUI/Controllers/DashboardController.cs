using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Bakery.WebUI.Dtos.Categories;
using Bakery.WebUI.Dtos.Products;

namespace Bakery.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7210/api/Product/CountProduct");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData;

            var responseMessage1 = await client.GetAsync("https://localhost:7210/api/Product/LastProduct");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductLast = jsonData1;

            var responseMessage2 = await client.GetAsync("https://localhost:7210/api/Chef/CountChef");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ChefCount = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7210/api/Category/CountCategory");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:7210/api/Subscribe/CountSubscribe");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.SubscribeCount = jsonData4;

            var responseMessage5 = await client.GetAsync("https://localhost:7210/api/Service/CountService");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.ServiceCount = jsonData5;

            var responseMessage6 = await client.GetAsync("https://localhost:7210/api/Service/LastService");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.ServiceLast = jsonData6;

            var responseMessage7 = await client.GetAsync("https://localhost:7210/api/Testimonial/CountTestimonial");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.TestimonialCount = jsonData7;

            var responseMessage8 = await client.GetAsync("https://localhost:7210/api/Testimonial/LastTestimonial");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.TestimonialLast = jsonData8;

            var response = await client.GetAsync("https://localhost:7210/api/Product/with-category");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductWithCategoryDto>>(jsondata);

                var lastFiveProducts = values?
                    .OrderByDescending(x => x.ProductId)   // Son eklenenler üstte
                    .Take(5)                                // Sadece 5 kayıt
                    .ToList();

                return View(lastFiveProducts ?? new List<ProductWithCategoryDto>());
            }

            return View(new List<ProductWithCategoryDto>());
        }
    }
}
