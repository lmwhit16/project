using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _411Calendar.Models
{
    public class UserModel
    {
        public string UserID { get; set; }
        [Display(Name="User Name")]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}