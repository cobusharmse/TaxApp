using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.Models
{
    public abstract class TaxCalculationBaseModel
    {
        public string PostalCode { get; set; }
        public double AnnualIncome { get; set; }
        public abstract double CalculateTax<T>(T DataToUse,double Amount);
    }
}
