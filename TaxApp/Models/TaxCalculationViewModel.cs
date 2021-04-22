using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.Models
{
    public class TaxCalculationViewModel
    {
        [Required]
        [Display( Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Annual Income")]
        public double AnnualIncome { get; set; }
        public double CalculationResult { get; set; }
    }
}
