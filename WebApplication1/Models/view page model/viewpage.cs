using HoossH_Services.Models.Login;

namespace HoossH_Services.Models.view_page_model
{
    public class viewpage
    {
        public Guid LoginID { get; set; }
        public int Duration { get; set; }
        public string DurationValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<UserDropdown> Users { get; set; }
        public List<Customer> customers { get; set; }
    }
}
