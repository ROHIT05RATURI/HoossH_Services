namespace HoossH_Services.Models
{
    public class MarkAttendance
    {
        public DateTime AttendenceDate { get; set; }

        public string Status { get; set; }

        public string? location { get; set; }
        public string? description { get; set; }

        public bool isCheckedout { get; set; }

        public string CheckInStr { get; set; }
        public string CheckOutStr { get; set; }


        public DateTime Checkintime { get; set; }

        public DateTime? CheckoutTime { get; set; }
    }
}
