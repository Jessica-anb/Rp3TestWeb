﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3.Test.Data.Models
{
    public class Balance
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Category { get; set; }
        public decimal Amount { get; set; }      
    }
}
