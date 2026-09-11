using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllDashboard()
        {
            return View();
        }
    }
}
