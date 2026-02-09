using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebUI.ViewComponents
{
    public class AdminNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
