using Microsoft.AspNetCore.Mvc;
using HoossH_Services.Models.Login;
using HoossH_Service_DAL.Repositories;
using System.Threading.Tasks;

namespace HoossH_Services.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthRepository _authRepository;
        public LoginController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public IActionResult Index()
        {
            return View(new HoossH_Service_DAL.Models.LoginUser());
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] HoossH_Service_DAL.Models.LoginUser request)
        {
            if (request == null || string.IsNullOrEmpty(request.username) || string.IsNullOrEmpty(request.Password))
            {
                return Json(new { success = false, message = "Please enter username and password" });
            }

            try 
            {
                var user = await _authRepository.AuthenticateAsync(request.username, request.Password);

                if (user != null)
                {
                    return Json(new { success = true, redirect = Url.Action("AllDashboard","Dashboard") });
                }

                return Json(new { success = false, message = "Invalid username or password" });
            }
            catch (System.Exception ex)
            {
                return Json(new { success = false, message = "Database Error: " + ex.Message });
            }
        }

        public IActionResult Logout()
        {
        
            return RedirectToAction("Index", "Login");
        }
    }
}
