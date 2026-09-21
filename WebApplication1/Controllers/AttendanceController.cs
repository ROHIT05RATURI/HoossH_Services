using HoossH_Service_DAL.Repo;
using HoossH_Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HoossH_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        [HttpPost("Mark")]
        public async Task<IActionResult> MarkAttendance([FromBody] MarkAttendanceDto request)
        {
            try
            {
                // Claims se LoginId string format me nikalna
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid loginId))
                {
                    return Unauthorized(new { message = "Session expired or invalid login." });
                }

                bool isSuccess = false;

                if (request.Status == "Present")
                {
                    isSuccess = await _attendanceRepository.MarkCheckInAsync(loginId, request.Location);
                }
                else if (request.Status == "Checkout")
                {
                    isSuccess = await _attendanceRepository.MarkCheckOutAsync(loginId, request.Location, request.Description);
                }

                if (isSuccess)
                {
                    return Ok(new { success = true, message = "Attendance marked successfully" });
                }

                return BadRequest(new { success = false, message = "Attendance already marked or record not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
