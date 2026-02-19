using Bakery.WebUI.Dtos.Categories;
using Bakery.WebUI.Dtos.Products;

namespace Bakery.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<ProductWithCategoryDto> Products { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
    }
}
