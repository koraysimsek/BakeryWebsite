using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebUI.ViewComponents
{
    public class AdminSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
