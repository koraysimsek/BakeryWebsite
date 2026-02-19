using Bakery.WebApi.Entities;

namespace Bakery.WebApi.Dtos
{
    public class ProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
    }
}
