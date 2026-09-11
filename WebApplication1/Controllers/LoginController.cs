using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var model = new HoossH_Services.Models.Login.IndexViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login([FromBody] HoossH_Services.Models.LoginRequest request)
        {
            if (request != null && request.UserName == "admin" && request.Password == "admin")
            {

                return Json(new { success = true, redirect = Url.Action("AllDashboard","Dashboard") });
            }

            return Json(new { success = false, message = "Invalid username or password" });
        }

        public IActionResult Logout()
        {
        
            return RedirectToAction("Index", "Login");
        }
    }
}
