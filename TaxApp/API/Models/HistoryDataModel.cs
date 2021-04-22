using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.API.Models
{
    public class HistoryDataModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Salary { get; set; }
        public double TaxAmount { get; set; }
        public string TaxType { get; set; }
    }
}
