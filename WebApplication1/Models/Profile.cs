namespace HoossH_Services.Models
{
    public class Profile
    {
        public string? UserName { get; set; }
        public string? firstname { get; set; }
        public string? middlename { get; set; }
        public string? lastname { get; set; }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        public string? CompanyName { get; set; }

        public string? PhoneNo { get; set; }

        public string? PAN { get; set; }

        public string? AadharCard { get; set; }
        public string? AccountNo { get; set; }
        public string? IFSC { get; set; }

        public string? BankName { get; set; }

        public string? AccountHolder { get; set; }

        public string? Branch { get; set; }
        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PinCode { get; set; }

        public string? Country { get; set; }

        public Guid? CompanyId { get; set; }

        public Guid? LoginId { get; set; }


        public byte[] profileImg { get; set; }
        public IFormFile ProfileImage { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? AddressId { get; set; }

        public string? Area { get; set; }

        public string? district { get; set; }
    }
}
