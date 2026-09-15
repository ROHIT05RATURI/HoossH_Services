namespace HoossH_Services.Models
{
    public class Attendence
    {
        public long AttendanceId { get; set; }
        public Guid NewAttendanceId { get; set; }

        public Guid LoginId { get; set; }
        public Guid ManagerId { get; set; }

        public string totalTime { get; set; }

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
        public DateOnly AttendanceDate { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string Remarks { get; set; }

        public string? checkInLocation { get; set; }

        public string? checkOutLocation { get; set; }

        public string? checkOutDescription { get; set; }

        public TimeOnly? CheckinTime { get; set; }

        public TimeOnly? CheckOutTime { get; set; }

        public string name { get; set; }
        public string approvedattendencestatus { get; set; }

        public bool IsChecked { get; set; } = false;

        public string ManagerStatus { get; set; }

        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }

        public int LeaveDays { get; set; }
        public int presentCount { get; set; }
        public int absentCount { get; set; }


        // for Dyanamic Users columns

        public string? IsActiveStatus { get; set; }
        public string day { get; set; }

    }
}
