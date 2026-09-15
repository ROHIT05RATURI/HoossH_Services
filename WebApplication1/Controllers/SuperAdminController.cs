using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProfilePage()
        {
            return View();
        }   


    }
}
