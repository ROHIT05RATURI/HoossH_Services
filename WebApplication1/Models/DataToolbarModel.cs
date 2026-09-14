using HoossH_Services.Models.Login;

namespace HoossH_Services.Models
{
    public class DataToolbarModel
    {
        // 1. Search Box Customization
        public string SearchPlaceholder { get; set; } = "Search...";

        // 2. Dropdown Status Filters (e.g., Live, Ordered, Cancelled)
        public Dictionary<string, string> FilterOptions { get; set; }

        // 3. Sorting Options
        public List<ToolbarSortOption> SortOptions { get; set; }

        // 4. API / Form Routing ke liye
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        // 5. UI Toggles
        public bool ShowViewToggles { get; set; } = true; // Card, Grid, Table button

        // 6. Advanced/Custom Data (Jo JS mein payload ban ke wapas aayega)
        public Dictionary<string, string> CustomData { get; set; } = new Dictionary<string, string>();

        // 7. Custom HTML (Agar 2 Date pickers ya Amount range input daalna ho)
        public string CustomFilterHtml { get; set; }

        //8. Ye do properties apne DataToolbarModel class me add kar lo
        public bool IsSalesManager { get; set; }
        public string SalesPersons { get; set; }
    }

    // Sort Dropdown ke items ke liye choti si class
    public class ToolbarSortOption
    {
        public string Value { get; set; }      // e.g., "date_desc"
        public string Text { get; set; }       // e.g., "Newest First"
        public string IconClass { get; set; }  // e.g., "fa-regular fa-clock"
    }
}
