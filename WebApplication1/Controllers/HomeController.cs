using Microsoft.AspNetCore.Mvc;
using HoossH_Services.Models;
using HoossH_Service_DAL.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using HoossH_Service_DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System;

namespace HoossH_Services.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public HomeController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetCredentials()
        {
            return View(new ResetPasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetCredentials(ResetPasswordViewModel model)
        {
            try
            {
                // 1. Basic Validation
                if (string.IsNullOrEmpty(model.OldUsername) || string.IsNullOrEmpty(model.OldPassword))
                {
                    return Json(new { success = false, message = "Old Username and Password are required." });
                }

                bool isUpdatingPassword = !string.IsNullOrEmpty(model.NewPassword);
                bool isUpdatingUsername = !string.IsNullOrEmpty(model.NewUsername);

                if (!isUpdatingPassword && !isUpdatingUsername)
                {
                    return Json(new { success = false, message = "Please provide either a new username or a new password." });
                }

                // 2. Fetch User Id
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!Guid.TryParse(userIdString, out Guid currentLoginId) || currentLoginId == Guid.Empty)
                {
                    return Json(new { success = false, message = "User session expired. Please login again." });
                }

                // 3. Authenticate Current Details 
                // (Ye check karega ki old password sahi hai ya nahi)
                var currentUser = await _authRepository.AuthenticateAsync(model.OldUsername, model.OldPassword);
                if (currentUser == null)
                {
                    return Json(new { success = false, message = "Verification failed! Incorrect Old Username or Password." });
                }

                string currentHash = currentUser.hashpassword;
                bool passwordUpdated = false;
                bool usernameUpdated = false;

                // 4. Agar Password Update karna hai
                if (isUpdatingPassword)
                {
                    var hasher = new PasswordHasher<LoginUser>();
                    string hashedNewPassword = hasher.HashPassword(currentUser, model.NewPassword);

                    passwordUpdated = await _authRepository.UpdatePasswordAsync(currentLoginId, model.OldUsername, currentHash, hashedNewPassword);

                    if (!passwordUpdated)
                    {
                        return Json(new { success = false, message = "Failed to update password." });
                    }

                    // Password update hone ke baad DB me hash badal gaya hoga, isliye naya hash assign karein
                    currentHash = hashedNewPassword;
                }

                // 5. Agar Username Update karna hai
                if (isUpdatingUsername)
                {
                    // Check karein kisi aur ke paas ye username toh nahi hai
                    bool isTaken = await _authRepository.IsUsernameTakenAsync(model.NewUsername, currentLoginId);
                    if (isTaken)
                    {
                        return Json(new { success = false, message = "Username is already taken. Please choose another one." });
                    }

                    // Yahan par currentHash bhejenge (Agar password pehle update hua tha, toh naya hash jayega)
                    usernameUpdated = await _authRepository.UpdateUsernameAsync(currentLoginId, model.OldUsername, currentHash, model.NewUsername);

                    if (!usernameUpdated)
                    {
                        if (isUpdatingPassword && passwordUpdated)
                        {
                            return Json(new { success = true, message = "Password updated, but failed to update Username." });
                        }
                        return Json(new { success = false, message = "Failed to update username." });
                    }
                }

                // 6. Security: Update ke baad user ko logout karwa dein taaki wo naye credentials se login kare
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                // 7. Success Messages
                string successMsg = "Credentials updated successfully! Please login again.";
                if (isUpdatingPassword && !isUpdatingUsername) successMsg = "Password updated successfully! Please login again.";
                if (!isUpdatingPassword && isUpdatingUsername) successMsg = "Username updated successfully! Please login again.";

                return Json(new { success = true, message = successMsg });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
    }
}