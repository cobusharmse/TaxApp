using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.API.Models
{
    public class PostalCodeDataModel
    {
        public int Id { get; set; }
        public string PostalCodeDescription { get; set; }
        public string PostalCodeValue { get; set; }
    }
}
