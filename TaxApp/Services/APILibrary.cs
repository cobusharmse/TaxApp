using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using TaxApp.Interfaces;
using TaxApp.API.Models;

namespace TaxApp.Services
{
    public class APILibrary : IAPILibrary
    {
        public string _APIBase { get; set; }
        public APILibrary()
        {
            _APIBase = "https://localhost:44333";
            if(!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["APIBase"]))
            {
                _APIBase = System.Configuration.ConfigurationManager.AppSettings["APIBase"];
            }
        }
        public async Task<FlatRateTaxDataModel> GetFlatRateTaxTable(IHttpClientFactory HTTPclientFactory)
        {
            API.Models.FlatRateTaxDataModel returndata = new API.Models.FlatRateTaxDataModel();
            HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Get, _APIBase + "/api/FlatRateTaxTable");
            HttpClient client = HTTPclientFactory.CreateClient();
            HttpResponseMessage Response = await client.SendAsync(Request);
            if (Response.IsSuccessStatusCode)
            {
                returndata = await Response.Content.ReadFromJsonAsync<API.Models.FlatRateTaxDataModel>();
                return returndata;
            }
            else
            {
                throw new Exception("Return of Tax Table Failed");
            }
        }

        public async Task SaveHistory(IHttpClientFactory HTTPclientFactory,double Salary, double TaxAmount,string TaxType)
        {
            HttpClient client = HTTPclientFactory.CreateClient();
            HttpResponseMessage Response = await client.PostAsJsonAsync(_APIBase + "/api/History",new { Salary = Salary, TaxAmount = TaxAmount , TaxType = TaxType });
            if (Response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Update of Tax History Failed");
            }
        }
    
   
    public async Task<FlatValueTaxDataModel> GetFlatValueTaxTable(IHttpClientFactory HTTPclientFactory)
        {
            API.Models.FlatValueTaxDataModel returndata = new API.Models.FlatValueTaxDataModel();
            HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Get, _APIBase + "/api/FlatValueTaxTable");
            HttpClient client = HTTPclientFactory.CreateClient();
            HttpResponseMessage Response = await client.SendAsync(Request);
            if (Response.IsSuccessStatusCode)
            {
                returndata = await Response.Content.ReadFromJsonAsync<API.Models.FlatValueTaxDataModel>();
                return returndata;
            }
            else
            {
                throw new Exception("Return of Tax Table Failed");
            }
        }

        public async Task<List<API.Models.PostalCodeDataModel>> GetPostalCodes(IHttpClientFactory HTTPclientFactory)
        {
            List<API.Models.PostalCodeDataModel> returndata = new List<API.Models.PostalCodeDataModel>();
            HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Get, _APIBase + "/api/postalcode");
            HttpClient client = HTTPclientFactory.CreateClient();
            HttpResponseMessage Response = await client.SendAsync(Request);
            if(Response.IsSuccessStatusCode)
            {
                returndata = await Response.Content.ReadFromJsonAsync<List<API.Models.PostalCodeDataModel>>();
                return returndata;
            }
            else
            {
                throw new Exception("Return of PostalCodes Failed");
            }
        }

        public async Task<List<ProgressiveTaxTableDataModel>> GetProgressiveTaxTable(IHttpClientFactory HTTPclientFactory)
        {
            List<API.Models.ProgressiveTaxTableDataModel> returndata = new List<API.Models.ProgressiveTaxTableDataModel>();
            HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Get, _APIBase + "/api/ProgressiveTaxTable");
            HttpClient client = HTTPclientFactory.CreateClient();
            HttpResponseMessage Response = await client.SendAsync(Request);
            if (Response.IsSuccessStatusCode)
            {
                returndata = await Response.Content.ReadFromJsonAsync<List<API.Models.ProgressiveTaxTableDataModel>>();
                return returndata;
            }
            else
            {
                throw new Exception("Return of Tax Table Failed");
            }
        }

        public async Task<List<HistoryDataModel>> GetHistory(IHttpClientFactory HTTPclientFactory)
        {
            List<API.Models.HistoryDataModel> returndata = new List<API.Models.HistoryDataModel>();
            HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Get, _APIBase + "/api/History");
            HttpClient client = HTTPclientFactory.CreateClient();
            HttpResponseMessage Response = await client.SendAsync(Request);
            if (Response.IsSuccessStatusCode)
            {
                returndata = await Response.Content.ReadFromJsonAsync<List<API.Models.HistoryDataModel>>();
                return returndata;
            }
            else
            {
                throw new Exception("Return of History Failed");
            }
        }
    }
}
