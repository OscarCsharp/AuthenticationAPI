using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }


    }
}
