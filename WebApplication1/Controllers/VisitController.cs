using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRoutes()
        {
            return View();
        }
    }
}
