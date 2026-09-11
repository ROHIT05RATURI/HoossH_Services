using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllDashboard()
        {
            var model = new HoossH_Services.Models.Dashboard.AllDashboardViewModel();
            return View(model);
        }
    }
}
