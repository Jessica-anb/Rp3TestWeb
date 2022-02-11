using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rp3.Test.Mvc.Models
{
    public class TransactionEditModel
    {
        public int TransactionId { get; set; }
        public short TransactionTypeId { get; set; }
        public int CategoryId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string ShortDescription { get; set; }
        public string Notes { get; set; }
        public int IdLogin { get; set; } //JNB
        public decimal Amount { get; set; } //JNB

        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
        public IEnumerable<SelectListItem> TransactionTypeSelectList { get; set; }
    }
}