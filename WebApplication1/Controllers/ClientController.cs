using HoossH_Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddClient()
        {
            Client model = new Client();
            return View(model);
        }

        [HttpGet]
        public IActionResult ViewClient()
        {
            Client model = new Client();
            return View(model);
        }
    }
}
