using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxApp;
namespace TaxApp.Models
{
    public class TaxCalculationFlatValueModel : TaxCalculationBaseModel
    {
        public override double CalculateTax<T>(T DataToUse, double Amount)
        {
            API.Models.FlatValueTaxDataModel Table = DataToUse as API.Models.FlatValueTaxDataModel;
            double TaxPayable = 0;
            if (Amount < Table.MinValue)
            {
                double Percentage = Table.Rate / 100;
                TaxPayable = Amount * Percentage;
            }
            else
            {
                TaxPayable = Table.Value;
            }
            return Math.Round(TaxPayable, 2);
        }
    }
}
