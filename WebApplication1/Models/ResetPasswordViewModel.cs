namespace HoossH_Services.Models
{
    public class ResetPasswordViewModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string OldUsername { get; set; }
        public string OldPassword { get; set; }
        public string NewUsername { get; set; }
        public string NewPassword { get; set; }
    }
}
