using Bakery.WebUI.Dtos.Products;

namespace Bakery.WebUI.Dtos.Products
{
    public class ProductWithCategoryDto
    {
        [Newtonsoft.Json.JsonProperty("productId")]
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonProperty("name")]
        public string? Name { get; set; }
        [Newtonsoft.Json.JsonProperty("price")]
        public decimal Price { get; set; }
        [Newtonsoft.Json.JsonProperty("imageUrl")]
        public string? ImageUrl { get; set; }
        [Newtonsoft.Json.JsonProperty("description")]
        public string? Description { get; set; }
        [Newtonsoft.Json.JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [Newtonsoft.Json.JsonProperty("categoryName")]
        public string? CategoryName { get; set; }
    }
}
