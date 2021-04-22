using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApp.Models
{
    public class TaxCalculationprogressiveModel : TaxCalculationBaseModel
    {
        public override double CalculateTax<T>(T DataToUse, double Amount)
        {
            List<API.Models.ProgressiveTaxTableDataModel> Table = DataToUse as List<API.Models.ProgressiveTaxTableDataModel>;
            return Math.Round( ProgressiveTax(-1, Amount, Table),2);
        }

        private double ProgressiveTax(double LastStart, double Amount, List<API.Models.ProgressiveTaxTableDataModel> Table)
        {
            API.Models.ProgressiveTaxTableDataModel Item = Table.Single(s => s.From == LastStart+1);
            double AmountOfTax = 0;
            double Percentage = Item.Rate / 100;

            if (Item != null)
            {
                if(Amount > LastStart)
                {
                    if(Item.To == -1)
                    {
                        return AmountOfTax = (Amount - LastStart) * Percentage;
                    }
                    else if(Amount > Item.To)
                    {
                        if(LastStart == -1)
                        {
                            AmountOfTax = Item.To * Percentage;
                        }
                        else
                        {
                            AmountOfTax = (Item.To - LastStart) * Percentage;
                        }
                    }
                    else
                    {
                        if(LastStart == -1)
                        {
                            AmountOfTax = Amount  * Percentage;
                        }
                        else
                        {
                            AmountOfTax = (Amount - LastStart) * Percentage;
                        }
                       
                    }
                }
                else
                {
                    return AmountOfTax;
                }
            }
            return AmountOfTax + ProgressiveTax(Item.To, Amount, Table);


        }
    }
}
