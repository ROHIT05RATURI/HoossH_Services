using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoossH_Services.Models
{
    public class AddProductViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Product Title is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        
        public string ShortDescription { get; set; }
        
        public string? Tags { get; set; }
        
        public bool IsRefundable { get; set; } = true;

        public IFormFile? MainImage { get; set; }
        public List<IFormFile>? GalleryImages { get; set; }
    }
}
