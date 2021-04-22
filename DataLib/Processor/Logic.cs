using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLib.Interface;
namespace DataLib.Processor
{
    public class Logic:IDataBaseInterface
    {
       public void SaveHistory(double Salary, double TaxAmount, string TaxType,string ConnectionString)
        {
            DataLib.Models.HistoryDataModel HistoryObject = new Models.HistoryDataModel() { Salary = Salary, TaxAmount = TaxAmount, TaxType = TaxType };
            string SQL = @"insert into dbo.History (Salary,TaxAmount,TaxType) values (@Salary,@TaxAmount,@TaxType)";
            DataLib.SQLDataAccess.SQLDataAccess.SaveData<DataLib.Models.HistoryDataModel>(SQL, HistoryObject, ConnectionString);

        }

        public List<DataLib.Models.HistoryDataModel>ListHistory(string ConnectionString)
        {
            string SQL = @"Select * from dbo.History order by [DateTime]";
            return DataLib.SQLDataAccess.SQLDataAccess.loaddata<DataLib.Models.HistoryDataModel>(SQL, ConnectionString);
        }

        public List<DataLib.Models.FlatRateTaxDataModel>ListFlatRateTax(string ConnectionString)
        {
            string SQL = @"Select * from dbo.FlatRateTax";
            return DataLib.SQLDataAccess.SQLDataAccess.loaddata<DataLib.Models.FlatRateTaxDataModel>(SQL, ConnectionString);
        }

        public List<DataLib.Models.FlatValueTaxDataModel> ListFlatValueTax(string ConnectionString)
        {
            string SQL = @"Select * from dbo.FlatValueTax";
            return DataLib.SQLDataAccess.SQLDataAccess.loaddata<DataLib.Models.FlatValueTaxDataModel>(SQL, ConnectionString);
        }

        public List<DataLib.Models.ProgressiveTaxTableDataModel> ListProGressiveTax(string ConnectionString)
        {
            string SQL = @"Select * from dbo.ProGressiveTax";
            return DataLib.SQLDataAccess.SQLDataAccess.loaddata<DataLib.Models.ProgressiveTaxTableDataModel>(SQL, ConnectionString);
        }
    }
}
