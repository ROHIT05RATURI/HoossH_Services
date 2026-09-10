using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] HoossH_Services.Models.LoginRequest request)
        {
            if (request != null && request.UserName == "admin" && request.Password == "admin")
            {
                // Successful login
                return Json(new { success = true, redirect = Url.Action("Index", "Home") });
            }

            // Failed login
            return Json(new { success = false, message = "Invalid username or password" });
        }
    }
}
