using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebUI.ViewComponents
{
    public class DefaultHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
