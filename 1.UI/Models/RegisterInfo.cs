using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    //Login view model.
    public class RegisterInfo
    {
        [Required]
        [Display(Name = "NickName")]
        public string NickName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        //[Validations]//קיסטום של ולידציה המחייבת מספר זוגי של ספרות
        [StringLength(10, MinimumLength = 3)]
        public string Password { get; set; }
    }
}