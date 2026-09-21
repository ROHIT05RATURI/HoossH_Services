namespace HoossH_Services.Models
{
    public class MarkAttendanceDto
    {
        public Guid LoginId { get; set; }
        public string Status { get; set; }
        public DateTime AttendenceDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

    }
}

