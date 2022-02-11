using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3.Test.Data.Models
{
    [Table("tbLogin", Schema = "dbo")]
    public class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdLogin { get; set; }
        public string User { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Password { get; set; }
    }
}
