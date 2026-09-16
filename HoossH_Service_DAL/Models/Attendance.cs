using System;
using System.Collections.Generic;
using System.Text;

namespace HoossH_Service_DAL.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public string Status { get; set; } = "Present"; 
    }
}
