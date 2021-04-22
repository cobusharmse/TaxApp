using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.Models
{
    public class TaxTableViewModel
    {
        [Display (Name ="Tax Rate")]
        public double Rate { get; set; }
        [Display(Name = "Flat Tax Value")]
        public double Value { get; set; }
        [Display(Name = "Min Value For Flat Rate")]
        public double MinValue { get; set; }
        [Display(Name = "Start of Bracket")]
        public double From { get; set; }
        [Display(Name = "End of Bracket")]
        public double To { get; set; }
        [Display(Name = "Tax Type")]
        public string Type { get; set; }
    }
}
