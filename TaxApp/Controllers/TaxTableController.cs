using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxApp.Interfaces;

namespace TaxApp.Controllers
{
    public class TaxTableController : Controller
    {
        private IAPILibrary _APIlib;
        private IHttpClientFactory _Clientfactory;
        public TaxTableController(IAPILibrary APIlib, IHttpClientFactory Clientfactory)
        {
            _APIlib = APIlib;
            _Clientfactory = Clientfactory;
        }
        public async Task<IActionResult> List()
        {
            List<Models.TaxTableViewModel> list = new List<Models.TaxTableViewModel>();
            List<API.Models.ProgressiveTaxTableDataModel> ProgressiveTax = await _APIlib.GetProgressiveTaxTable(_Clientfactory);
            foreach (API.Models.ProgressiveTaxTableDataModel Item in ProgressiveTax)
            {
                list.Add(new Models.TaxTableViewModel() { Type = "Progessive", Rate = Item.Rate, From = Item.From, To = Item.To });
            }
            API.Models.FlatValueTaxDataModel FlatValueTax = await _APIlib.GetFlatValueTaxTable(_Clientfactory);
            list.Add(new Models.TaxTableViewModel() { Type = "FlatValue", Rate = FlatValueTax.Rate, MinValue = FlatValueTax.MinValue, Value = FlatValueTax.Value });
            API.Models.FlatRateTaxDataModel FlatRateTax = await _APIlib.GetFlatRateTaxTable(_Clientfactory);
            list.Add(new Models.TaxTableViewModel() { Type = "FlatRate", Rate = FlatRateTax.Rate});
            return View(list);
        }
    }
}
