using Microsoft.AspNetCore.Mvc;
using HoossH_Services.Models;
using HoossH_Service_DAL.Repo;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using HoossH_Service_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace HoossH_Services.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public TeamController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Attendance()
        {
            var model = new List<Attendance>();
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (Guid.TryParse(userIdString, out Guid loginId))
            {
                model = await _attendanceRepository.GetUserAttendanceAsync(loginId);
            }

            ViewBag.daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAttendence([FromBody] MarkAttendanceDto dto)
        {
            try
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid loginId))
                {
                    return Unauthorized("User identity not found. Please log in again.");
                }

                bool isSuccess = false;

                if (dto.Status == "Present")
                {
                    // Check if date is provided by UI, otherwise send null (for today's checkin)
                    DateTime? manualDate = dto.AttendenceDate == DateTime.MinValue ? (DateTime?)null : dto.AttendenceDate;

                    isSuccess = await _attendanceRepository.MarkCheckInAsync(loginId, dto.Location, manualDate);
                }
                else if (dto.Status == "Checkout")
                {
                    isSuccess = await _attendanceRepository.MarkCheckOutAsync(loginId, dto.Location, dto.Description);
                }

                if (isSuccess)
                {
                    return Ok(new { success = true, message = "Attendance marked successfully" });
                }

                return BadRequest("Could not update attendance.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}