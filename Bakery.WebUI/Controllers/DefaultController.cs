using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
