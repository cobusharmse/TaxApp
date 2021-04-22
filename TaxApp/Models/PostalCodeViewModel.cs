using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaxApp.Models
{
    public class PostalCodeViewModel
    {
        [Display(Name = "Postal Code")]
        public string PostalCodeDescription { get; set; }
        [Display(Name = "Tax Type")]
        public string PostalCodevalue { get; set; }
    }
}
