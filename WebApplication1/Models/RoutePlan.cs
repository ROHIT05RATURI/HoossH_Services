namespace HoossH_Services.Models
{
    public class RoutePlan
    {
        public List<Routes>? RoutesByDate { get; set; }

        public List<Routes>? BacklogRoutes { get; set; }
        public List<Routes>? ManagerBacklogRoutes { get; set; }

        public List<Routes>? TodayRoutes { get; set; }

        //public List<UserDropdown> Users { get; set; }

        //public bool isFirstLogin { get; set; }
        //public List<DailyDetails> dailyDetails { get; set; }
        //public List<Customer> CustomerListWithID { get; set; }
        //public List<SelectListItem> SalesPersons { get; set; }
    }
}
