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
            return View(new LoginRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return Json(new { success = false, message = "Please enter username and password" });
            }

            try 
            {
                // Real SQL query call se data fetch hoga yahan
                var user = await _authRepository.AuthenticateAsync(request.Username, request.Password);

                if (user != null)
                {
                    // Login successful, ab aage badho
                    return Json(new { success = true, redirect = Url.Action("AllDashboard","Dashboard") });
                }

                return Json(new { success = false, message = "Invalid username or password" });
            }
            catch (System.Exception ex)
            {
                // Agar SQL mein koi error aaye (jaise table name galat ho) toh error message frontend par bhejo
                return Json(new { success = false, message = "Database Error: " + ex.Message });
            }
        }

        public IActionResult Logout()
        {
        
            return RedirectToAction("Index", "Login");
        }
    }
}
