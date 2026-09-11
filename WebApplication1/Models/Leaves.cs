using System.ComponentModel.DataAnnotations.Schema;

namespace HoossH_Services.Models
{
    public class Leaves
    {
        public Guid LeaveId { get; set; }
        public Guid AllocationID { get; set; }
        public Guid LoginId { get; set; }
        public string FullName { get; set; }

        public Guid LeaveType { get; set; }
        public string Name { get; set; } // 'name' ko 'Name' kar diya gaya hai (C# standard)
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalDays { get; set; }

        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } // 'status' ko 'Status' kar diya gaya hai
        public string ManagerName { get; set; }
        public string ApprovalStatus { get; set; }
        public Guid NewApprovedBy { get; set; }

        // Dynamic JSON field (for FOR JSON PATH approach)
        public string AllocationJSON { get; set; }

        public decimal AllocatedDays { get; set; }
        public decimal UsedDays { get; set; }
        public decimal RemainingDays { get; set; }
        public decimal ActualLeaves { get; set; }

        public decimal CasualLeaves { get; set; }
        public decimal EarnedLeaves { get; set; }
        public decimal OtherLeaves { get; set; }

        public decimal TotalAllocatedDays { get; set; }
        public decimal TotalAllocatedCasual { get; set; }
        public decimal TotalAllocatedEarned { get; set; }
        public decimal TotalAllocatedOthers { get; set; }
        public bool IsChecked { get; set; } = false;

        public List<Leaves> LeaveTypes { get; set; }
        public List<Leaves> GetLeaves { get; set; }
        // Keep both names for backwards compatibility with views and form fields
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

        // Provide lowercase aliases for older views that used 'name' and 'status'
        [NotMapped]
        public string name { get => Name; set => Name = value; }

        [NotMapped]
        public string status { get => Status; set => Status = value; }
    }
}
