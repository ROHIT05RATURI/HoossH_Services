using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoossH_Services.Controllers
{
    public class FlowController : Controller
    {
        // 1. GET: /Flow/GetPincodeDetails?pincode=123456
        [HttpGet]
        public IActionResult GetPincodeDetails(string pincode)
        {
            // Yahan par hum database se pincode ke details nikalte hain.
            // Abhi ke liye hum dummy (fake) data bhej rahe hain.
            var areas = new List<object>();

            if (pincode == "400001")
            {
                areas.Add(new { area = "Fort", city = "Mumbai", district = "Mumbai City", state = "Maharashtra", country = "India" });
                areas.Add(new { area = "Colaba", city = "Mumbai", district = "Mumbai City", state = "Maharashtra", country = "India" });
            }
            else
            {
                // Default dummy response
                areas.Add(new { area = "Sample Area", city = "Sample City", district = "Sample District", state = "Sample State", country = "India" });
            }

            return Json(areas); // JSON format mein data return karte hain jo UI mein use hota hai.
        }

        // 2. POST: /Flow/AddNewCustomer
        [HttpPost]
        public IActionResult AddNewCustomer([FromForm] object formData)
        {
            // Yahan par form ka data aayega jise hum database mein save karenge.
            // Abhi hum bas ek success message return kar rahe hain.
            
            // Example:
            // string orgName = Request.Form["CustomerName"];
            // string address = Request.Form["CustomerAddress"];
            
            return Json(new { success = true, message = "Client details saved successfully in Database!" });
        }
    }
}
