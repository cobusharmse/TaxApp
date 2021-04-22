using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaxApp.Interfaces
{
    public interface IAPILibrary
    {
        public string _APIBase { get; set; }
        public Task<List<API.Models.PostalCodeDataModel>> GetPostalCodes(IHttpClientFactory HTTPclientFactory);
        public Task<List<API.Models.ProgressiveTaxTableDataModel>> GetProgressiveTaxTable(IHttpClientFactory HTTPclientFactory);
        public Task<API.Models.FlatRateTaxDataModel> GetFlatRateTaxTable(IHttpClientFactory HTTPclientFactory);
        public Task<API.Models.FlatValueTaxDataModel> GetFlatValueTaxTable(IHttpClientFactory HTTPclientFactory);
        public Task SaveHistory(IHttpClientFactory HTTPclientFactory, double Salary, double TaxAmount, string TaxType);
        public Task<List<API.Models.HistoryDataModel>> GetHistory(IHttpClientFactory HTTPclientFactory);
    }
}
