using Bakery.WebUI.Dtos.Categories;

namespace Bakery.WebUI.Dtos.Products
{
    public class ProductWithCategoryDto
    {
        public int productId { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? imageUrl { get; set; }
        public int categoryId { get; set; }

        public string? categoryName { get; set; }
    }
}
