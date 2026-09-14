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

        public IActionResult ViewAttendence()
        {
            return View();
        }



        public IActionResult LeaveManagement()
        {
            return View(new Leaves());
        }

        public IActionResult ViewApprovedHistory()
        {
            return View(new Leaves());
        }
    }


}
