using HoossH_Services.Models.view_page_model;

namespace HoossH_Services.Models
{
    public class PageHeaderModel
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CountText { get; set; }
        public string BadgeColorClass { get; set; } = "default";

        public int Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Users { get; set; }

        public string TargetController { get; set; }
        public string TargetAction { get; set; }

        public string enquiryvalue { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        // New Properties for the Detailed UI
        public bool ShowDetailedUI { get; set; } = true; // Toggle field
        public string LastUpdated { get; set; }
        public string TotalValue { get; set; } // e.g., "₹ 12.45L"
        public string ValueGrowth { get; set; } // e.g., "12.5%"
        public string TotalVolume { get; set; } // e.g., "385"
        public string VolumeGrowth { get; set; } // e.g., "8.3%"

        public string Manager { get; set; }
        public string SalesPerson { get; set; }

        public bool ShowYearFilter { get; set; } = false;
        public int? SelectedYear { get; set; }
    }
}
