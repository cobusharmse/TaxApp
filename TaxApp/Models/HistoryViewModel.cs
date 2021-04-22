using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.Models
{
    public class HistoryViewModel
    {
        [Display(Name = "Date Added")]
        public DateTime DateTime { get; set; }
        [Display(Name = "Salary")]
        public double Salary { get; set; }
        [Display(Name = "Tax Amount")]
        public double TaxAmount { get; set; }
        [Display(Name = "Tax Type")]
        public string TaxType { get; set; }
    }
}
