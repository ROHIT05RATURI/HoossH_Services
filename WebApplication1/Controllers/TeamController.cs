using Microsoft.AspNetCore.Mvc;

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
            var model = new HoossH_Services.Models.Team.AttendenceViewModel();
            return View(model);
        }

        public IActionResult ViewAttendence()
        {
            var model = new HoossH_Services.Models.Team.ViewAttendenceViewModel();
            return View(model);
        }

        
    }


}
