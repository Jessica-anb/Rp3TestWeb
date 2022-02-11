using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rp3.Test.Mvc.Models
{
    public class LoginViewModel
    {
        public int IdLogin { get; set; }
        public string User { get; set; }
        public string FullName { get; set; }
    }
}