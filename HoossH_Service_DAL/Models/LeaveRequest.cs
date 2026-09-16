using System;
using System.Collections.Generic;
using System.Text;

namespace HoossH_Service_DAL.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string LeaveType { get; set; } = "Casual"; // Casual, Sick, Annual
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
