using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Interface
{
    public interface IDataBaseInterface
    {
        public void SaveHistory(double Salary, double TaxAmount, string TaxType, string ConnectionString);
        public List<DataLib.Models.HistoryDataModel> ListHistory( string ConnectionString);
        public List<DataLib.Models.FlatRateTaxDataModel> ListFlatRateTax(string ConnectionString);
        public List<DataLib.Models.ProgressiveTaxTableDataModel> ListProGressiveTax(string ConnectionString);
        public List<DataLib.Models.FlatValueTaxDataModel> ListFlatValueTax(string ConnectionString);
    }
}
