using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.API.Models
{
    public class FlatValueTaxDataModel
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public double Value { get; set; }
        public double MinValue { get; set; }
    }
}
