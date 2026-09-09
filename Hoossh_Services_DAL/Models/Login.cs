using System;
using System.Collections.Generic;
using System.Text;

namespace Hoossh_Services_DAL.Models
{
    public class Login
    {
        public string userName { get; set; }
        public string password { get; set; }
        public Guid LoginId { get; set; }
        public string fullName { get; set; }
        public string role { get; set; }
        public string hashedPassword { get; set; }
        public Guid companyID { get; set; }
        public string company { get; set; }
    }

}
