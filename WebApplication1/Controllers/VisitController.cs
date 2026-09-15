using HoossH_Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoossH_Services.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRoutes()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Addproduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: yahan pe database me save karne ka logic aayega

                // Main Image processing
                if (model.MainImage != null && model.MainImage.Length > 0)
                {
                    // Example: var fileName = Path.GetFileName(model.MainImage.FileName);
                    // Save to server
                }

                // Gallery Images processing
                if (model.GalleryImages != null && model.GalleryImages.Count > 0)
                {
                    foreach (var image in model.GalleryImages)
                    {
                        if (image != null && image.Length > 0)
                        {
                            // Save each gallery image
                        }
                    }
                }

                // Save hone ke baad redirect karna
                return RedirectToAction("Addproduct"); 
            }

            // Agar model invalid hai (validation errors), to same form errors ke sath return karo
            return View("Addproduct", model);
        }
    }
}
