using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class RegisterModel
    {
        [Required]
        public string FName { set; get; }

        [Required]
        public string LName { set; get; }

        [Required]
        [RegularExpression(@"((09|03|05|07|08)+([0-9]{8}))", ErrorMessage = "Phone Number is invalid!")]
        public string PhoneNumber { set; get; }

        [Required]
        public string Address { set; get; }

        [Required]
        public string UserName { set; get; }

        [Required]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { set; get; }

        [Required]
        [MinLength(6,ErrorMessage = "Minimum length is 6 characters")]
        public string Password { set; get; }
        
        [Required]
        [Compare("Password",ErrorMessage = "Confirm password is not correct !")]
        public string ConfirmPassword { set; get; }
    }

    public class LoginModel
    {
        [Required]
        public string TxtUserName { set; get; }

        [Required]
        [MinLength(6, ErrorMessage = "Minimum length is 6 characters")]
        public string TxtPassWord { set; get; }

    }
}