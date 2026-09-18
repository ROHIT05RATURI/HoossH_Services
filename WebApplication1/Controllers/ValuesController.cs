using HoossH_Service_DAL.Models; // Model ka reference yahan add karna zaroori hai
using HoossH_Service_DAL.Repositories;
using HoossH_Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HoossH_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _authRepository.AuthenticateAsync(request.Username, request.Password);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }

            return Ok(new
            {
                Message = "Login successful",
                UserId = user.loginid,
                Username = user.username,
            });
        }

    }
}