using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxApp.Interfaces;

namespace TaxApp.Controllers
{
    public class PostalCodeController : Controller
    {
        private IAPILibrary _APIlib;
        private IHttpClientFactory _Clientfactory;
        public PostalCodeController(IAPILibrary APIlib, IHttpClientFactory Clientfactory)
        {
            _APIlib = APIlib;
            _Clientfactory = Clientfactory;
        }
        public async Task<IActionResult> List()
        {
            List<API.Models.PostalCodeDataModel> PostalCodes = await _APIlib.GetPostalCodes(_Clientfactory);
            List<Models.PostalCodeViewModel> list = new List<Models.PostalCodeViewModel>();
            foreach (API.Models.PostalCodeDataModel Item in PostalCodes)
            {
                list.Add(new Models.PostalCodeViewModel() { PostalCodeDescription = Item.PostalCodeDescription, PostalCodevalue = Item.PostalCodeValue });
            }
            return View(list);
        }
    }
}
