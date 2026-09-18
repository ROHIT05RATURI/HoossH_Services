namespace HoossH_Service_DAL.Models
{
    public class LoginUser
    {
        public System.Guid loginid { get; set; }
        public string username { get; set; } = string.Empty;
        public int? role { get; set; } = null;
        public bool active { get; set; }
        public string hashpassword { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

}
