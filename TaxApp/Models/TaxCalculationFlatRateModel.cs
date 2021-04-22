using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.Models
{
    public class TaxCalculationFlatRateModel : TaxCalculationBaseModel
    {
        public override double CalculateTax<T>(T DataToUse,double Amount)
        {
            API.Models.FlatRateTaxDataModel Table = DataToUse as API.Models.FlatRateTaxDataModel;
            double Percentage = Table.Rate / 100;
            double TaxPayable = Amount * Percentage;
            return Math.Round(TaxPayable, 2);
        }
    }
}
