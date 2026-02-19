namespace Bakery.WebUI.Dtos.Categories
{
    public class ResultCategoryDto
    {
        [Newtonsoft.Json.JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [Newtonsoft.Json.JsonProperty("categoryName")]
        public string? CategoryName { get; set; }
    }
}
