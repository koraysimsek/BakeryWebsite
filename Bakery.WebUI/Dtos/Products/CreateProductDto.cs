namespace Bakery.WebUI.Dtos.Products
{
    public class CreateProductDto
    {
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? imageUrl { get; set; }
        public string? description { get; set; }
        public int categoryId { get; set; }
    }
}
