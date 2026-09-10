namespace HoossH_Services.Models.Login
{
    public class User
    {
        public string hashedPassword { get; set; }
        public DateTime lastDate { get; set; }
        public DateTime endDate { get; set; }
        public string Series { get; set; }
        public string OrganizationName { get; set; }
        public string TerritoryName { get; set; }
        public string ManagerName { get; set; }
        public int TotalVisits { get; set; }
        public string fullName { get; set; }
        public Guid NewUserId { get; set; }
        public Guid? LevelId { get; set; }
        public Guid? TerritoryId { get; set; }
        public Guid LeaderId { get; set; }
        public Guid LoginId { get; set; }
        public string? firstName { get; set; }

        public string? IsActiveStatus { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }
        public string? PanNumber { get; set; }
        public string? AdharNumber { get; set; }
        public string? ContactNumber { get; set; }
        public string? AddressLine1 { get; set; }
        public string? Pincode { get; set; }

        public string District { get; set; }
        public string Country { get; set; }


        public string? State { get; set; }

        public string? Area { get; set; }
        public string? City { get; set; }
        public string? IfscCode { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public DateTime startDate { get; set; }


        public string userName { get; set; }
        /*public int Roles { get; set; }*/
        public string password { get; set; }
        public string? company { get; set; }
        public Guid companyID { get; set; }
        public Guid InquiryId { get; set; }
        public string? email { get; set; }
        public string? phoneNo { get; set; }
        public DateTime DOJ { get; set; }

        public string? DepartmentLocation { get; set; }

        public DateTime DOB { get; set; }

        public string Department { get; set; }

        public string? bloodGroup { get; set; }
        public string? reportingManager { get; set; }
        public IFormFile? profileImage { get; set; }
        public byte[]? ProfileImg { get; set; }
        public string role { get; set; }
        public int? UserID { get; set; }
        public Guid managerId { get; set; }
        public Guid OwnerID { get; set; }

        public string? name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Status { get; set; }

        //public List<ProductCatelogue> items { get; set; }


    }
    public class UserDropdown
    {
        public Guid LoginId { get; set; }
        public Guid TerritoryId { get; set; }
        public string? FullName { get; set; }
        public string? TerritoryName { get; set; }

        public string userName { get; set; }

        public string role { get; set; }

        public string IsActiveStatus { get; set; }

        public Guid? ManagerId { get; set; }

    }


    public class UserLocation
    {
        public Guid LoginId { get; set; }

        public string CurrentLocation { get; set; }


        public string FullName { get; set; } = string.Empty;

        public string LocationType { get; set; }


        public DateTime CheckinTime { get; set; }

        public string CustomerName { get; set; }

    }


    public class UserLocationData
    {
        public List<UserDropdown> Users { get; set; }

        public List<UserLocation> locations { get; set; }


    }
}
