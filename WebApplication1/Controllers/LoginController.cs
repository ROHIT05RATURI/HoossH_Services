using Microsoft.AspNetCore.Mvc;
using HoossH_Services.Models.view_page_model;
using HoossH_Service_DAL.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return View();
            }
            return View(new HoossH_Service_DAL.Models.LoginUser());
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
