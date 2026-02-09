using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebUI.ViewComponents
{
    public class AdminHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
