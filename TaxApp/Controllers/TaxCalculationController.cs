using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxApp.Interfaces;

namespace TaxApp.Controllers
{
    public class TaxCalculationController : Controller
    {
        private IAPILibrary _APIlib;
        private IHttpClientFactory _Clientfactory;
        public TaxCalculationController(IAPILibrary APIlib,IHttpClientFactory Clientfactory)
        {
            _APIlib = APIlib;
            _Clientfactory = Clientfactory;
        }
        public async Task<IActionResult> TaxCalculation()
        {
            List<API.Models.PostalCodeDataModel> PostalCodes = await _APIlib.GetPostalCodes(_Clientfactory);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach(API.Models.PostalCodeDataModel Item in PostalCodes)
            {
                list.Add(new SelectListItem() { Text = Item.PostalCodeDescription, Value = Item.PostalCodeValue });
            }
            ViewBag.PostalCodes = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaxCalculation(TaxApp.Models.TaxCalculationViewModel TaxcaculationData )
        {
            if(ModelState.IsValid)
            {

                switch (TaxcaculationData.PostalCode.ToLower())
                {
                    case "progressive":
                        List<API.Models.ProgressiveTaxTableDataModel> ProgressiveTax = await _APIlib.GetProgressiveTaxTable(_Clientfactory);
                        Models.TaxCalculationprogressiveModel Progressive = new Models.TaxCalculationprogressiveModel();
                        TaxcaculationData.CalculationResult = Progressive.CalculateTax<List<API.Models.ProgressiveTaxTableDataModel>>(ProgressiveTax, TaxcaculationData.AnnualIncome);
                        break;
                    case "flatvalue":
                        API.Models.FlatValueTaxDataModel FlatValueTax = await _APIlib.GetFlatValueTaxTable(_Clientfactory);
                        Models.TaxCalculationFlatValueModel FlatValue = new Models.TaxCalculationFlatValueModel();
                        TaxcaculationData.CalculationResult = FlatValue.CalculateTax<API.Models.FlatValueTaxDataModel>(FlatValueTax, TaxcaculationData.AnnualIncome);
                        break;
                    case "flatrate":
                        API.Models.FlatRateTaxDataModel FlatRateTax = await _APIlib.GetFlatRateTaxTable(_Clientfactory);
                        Models.TaxCalculationFlatRateModel FlatRate = new Models.TaxCalculationFlatRateModel();
                        TaxcaculationData.CalculationResult = FlatRate.CalculateTax<API.Models.FlatRateTaxDataModel>(FlatRateTax, TaxcaculationData.AnnualIncome);
                        break;
                    default:
                        break;
                }
                await _APIlib.SaveHistory(_Clientfactory, TaxcaculationData.AnnualIncome, TaxcaculationData.CalculationResult, TaxcaculationData.PostalCode);
                List<API.Models.PostalCodeDataModel> PostalCodes = await _APIlib.GetPostalCodes(_Clientfactory);
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (API.Models.PostalCodeDataModel Item in PostalCodes)
                {
                    if(TaxcaculationData.PostalCode == Item.PostalCodeValue)
                    {
                        list.Add(new SelectListItem() { Text = Item.PostalCodeDescription, Value = Item.PostalCodeValue,Selected = true});
                    }
                    else
                    {
                        list.Add(new SelectListItem() { Text = Item.PostalCodeDescription, Value = Item.PostalCodeValue });
                    }
                    
                }
                ViewBag.PostalCodes = list;
                return View(TaxcaculationData);
            }
            else
            {
                return View();
            }

        }

    
    }
}
