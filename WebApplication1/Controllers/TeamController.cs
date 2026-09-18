using Microsoft.AspNetCore.Mvc;
using HoossH_Services.Models;

namespace HoossH_Services.Controllers
{
    public class TeamController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Attendence()
        {
            return View();
        }

        public IActionResult LeaveManagement()
        {
            var model = new HoossH_Services.Models.Leaves();
            return View(model);
        }

        public IActionResult ViewApprovedHistory()
        {
            ManagerAttendance model = new ManagerAttendance();
            return View(model);
        }
    }


}
