namespace HoossH_Service_DAL.Models
{
    public class LoginUser
    {
        public System.Guid loginid { get; set; }
        public string username { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public bool active { get; set; }
        public string hashpassword { get; set; } = string.Empty;
    }
}
