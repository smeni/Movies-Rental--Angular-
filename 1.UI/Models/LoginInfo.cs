using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    //Login view model.
    public class LoginInfo
    {
        [Required]
        [Display(Name = "דואר אלקטרוני")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "סיסמה")]
        [StringLength(10, MinimumLength = 4)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}