using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Amideploy2._0.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        [Display(Name = "UserName")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username Required Minimum 3 and Maximum 15 Characters")]
        [DataType(DataType.Text)]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Password Required Minimum 3 and Maximum 15 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}