using Microsoft.AspNetCore.Mvc;

namespace NetCore.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View("~/views/shared/error.cshtml");
        }
    }
}
