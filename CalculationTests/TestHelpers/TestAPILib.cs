using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaxApp.API.Models;
using TaxApp.Interfaces;

namespace CalculationTests.TestHelpers
{
    class TestAPILib : TaxApp.Interfaces.IAPILibrary
    {
        public string _APIBase { get; set; }
        public Task<FlatRateTaxDataModel> GetFlatRateTaxTable(IHttpClientFactory HTTPclientFactory)
        {
            Task<FlatRateTaxDataModel> retTask = new Task<FlatRateTaxDataModel>(() => new TaxApp.API.Models.FlatRateTaxDataModel() { Rate = 17.5 });
            retTask.Start();
            return retTask;
                
        }

        public Task<FlatValueTaxDataModel> GetFlatValueTaxTable(IHttpClientFactory HTTPclientFactory)
        {
            Task<FlatValueTaxDataModel> retTask = new Task<FlatValueTaxDataModel>(() => new FlatValueTaxDataModel() { Rate = 5, Value = 10000, MinValue = 200000 });
            retTask.Start();
            return retTask;
        }

        public Task<HistoryDataModel> GetHistory(IHttpClientFactory HTTPclientFactory)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostalCodeDataModel>> GetPostalCodes(IHttpClientFactory HTTPclientFactory)
        {
            List<PostalCodeDataModel> retval = new List<PostalCodeDataModel>();
                retval.Add(new PostalCodeDataModel() { PostalCodeDescription = "7441", PostalCodeValue = "Progressive" });
                retval.Add(new PostalCodeDataModel() { PostalCodeDescription = "A100", PostalCodeValue = "FlatValue" });
                retval.Add(new PostalCodeDataModel() { PostalCodeDescription = "7000", PostalCodeValue = "Flatrate" });
                retval.Add(new PostalCodeDataModel() { PostalCodeDescription = "1000", PostalCodeValue = "Progressive" });
            Task<List<PostalCodeDataModel>> retTask = new Task<List<PostalCodeDataModel>>(() => { return retval; });
            retTask.Start();
            return retTask;
        }

        public Task<List<ProgressiveTaxTableDataModel>> GetProgressiveTaxTable(IHttpClientFactory HTTPclientFactory)
        {
            List<ProgressiveTaxTableDataModel> retval = new List<ProgressiveTaxTableDataModel>();
            retval.Add(new ProgressiveTaxTableDataModel() { Rate = 10, From = 0, To = 8350 });
            retval.Add(new ProgressiveTaxTableDataModel() { Rate = 15, From = 8351, To = 33950 });
            retval.Add(new ProgressiveTaxTableDataModel() { Rate = 25, From = 33951, To = 82250 });
            retval.Add(new ProgressiveTaxTableDataModel() { Rate = 28, From = 82251, To = 171550 });
            retval.Add(new ProgressiveTaxTableDataModel() { Rate = 33, From = 171551, To = 372950 });
            retval.Add(new ProgressiveTaxTableDataModel() { Rate = 35, From = 372951, To = -1 });
            Task<List<ProgressiveTaxTableDataModel>> retTask = new Task<List<ProgressiveTaxTableDataModel>>(() => { return retval; });
            retTask.Start();
            return retTask;
        }

        public Task SaveHistory(IHttpClientFactory HTTPclientFactory, double Salary, double TaxAmount, string TaxType)
        {
            Task retTask = new Task(() => { return; });
            retTask.Start();
            return retTask;
        }

        Task<List<HistoryDataModel>> IAPILibrary.GetHistory(IHttpClientFactory HTTPclientFactory)
        {
            List<HistoryDataModel> retval = new List<HistoryDataModel>();
            Task<List<HistoryDataModel>> retTask = new Task<List<HistoryDataModel>>(() => { return retval; });
            retTask.Start();
            return retTask;
        }
    }
}
