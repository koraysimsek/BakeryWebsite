using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebUI.ViewComponents
{
    public class DefaultNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
