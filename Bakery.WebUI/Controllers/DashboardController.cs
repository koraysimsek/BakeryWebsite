using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
