using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HoossH_Service_DAL.Models
{
    public class Addproduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string? ShortDescription { get; set; }
        public string? Tags { get; set; }
        public bool IsRefundable { get; set; } = true;
    }
}
