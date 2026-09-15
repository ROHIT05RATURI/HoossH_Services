using HoossH_Services.Models.view_page_model;

namespace HoossH_Services.Models
{
    public class DataToolbarModel
    {
        public string SearchPlaceholder { get; set; } = "Search...";

        public Dictionary<string, string> FilterOptions { get; set; }

        public List<ToolbarSortOption> SortOptions { get; set; }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public bool ShowViewToggles { get; set; } = true; 

        public Dictionary<string, string> CustomData { get; set; } = new Dictionary<string, string>();

        public string CustomFilterHtml { get; set; }

        public bool IsSalesManager { get; set; }
        public IEnumerable<dynamic> SalesPersons { get; set; } = Enumerable.Empty<dynamic>();
    }

    public class ToolbarSortOption
    {
        public string Value { get; set; }      
        public string Text { get; set; }       
        public string IconClass { get; set; }  
    }
}
