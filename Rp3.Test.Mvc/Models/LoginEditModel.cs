using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rp3.Test.Mvc.Models
{
    public class LoginEditModel
    {
        [Display(Name = "User"), Required]
        public string User { get; set; }
        [Display(Name = "Password"), Required]
        public string Password { get; set; }
    }
}