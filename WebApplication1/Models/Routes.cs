namespace HoossH_Services.Models
{
    public class Routes
    {
        public Guid RouteID { get; set; }
        public Guid customerid { get; set; }

        // Added missing field used in the view
        public string customerName { get; set; }
        public string? Industry { get; set; }
        public string? IndustryType { get => Industry; set => Industry = value; }
        public string TerritoryName { get; set; }
        public byte[]? SalesPersonImg { get; set; }
        public byte[]? salespersonimage
        {
            get => SalesPersonImg;
            set => SalesPersonImg = value;
        }
        public byte[]? SalespersonImage
        {
            get => SalesPersonImg;
            set => SalesPersonImg = value;
        }

        public Guid VisitId { get; set; } = Guid.Empty;
        public Guid CreatedFromVisitId { get; set; } = Guid.Empty;

        public TimeOnly AppointmentTime { get; set; }

        // --- NEWLY ADDED TIMING FIELDS ---
        public TimeOnly Intime { get; set; }
        public TimeOnly OutTime { get; set; }
        public int Duration { get; set; }
        // ---------------------------------

        public DateTime RouteDate { get; set; }
        public DateTime ReAppointmentDate { get; set; }
        public DateTime LastVisitDate { get; set; }
        public string AppointmentTimeText { get; set; }
        public string? Area { get; set; }
        public string CustomerStatus { get; set; }
        public string? Priority { get; set; }
        public int PriorityType { get; set; }
        public string ContactPerson { get; set; }
        public string contactNumber { get; set; }
        public Guid Loginid { get; set; }
        //public Guid NewUserId { get; set; }
        public int userID { get; set; }
        public string Username { get; set; }
        public string VisitPurpose { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Distance { get; set; }

        public string scheduledtime { get; set; }
        public string status { get; set; }
        public int dueDays { get; set; }
        public bool IsLoggedIn { get; set; }
        public int TotalVisit { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public decimal LeadAmount { get; set; }

        public decimal SalesAmount { get; set; }

        public string? IsActiveStatus { get; set; }
    }
}
