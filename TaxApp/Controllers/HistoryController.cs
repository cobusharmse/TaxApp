using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxApp.Interfaces;

namespace TaxApp.Controllers
{
    public class HistoryController : Controller
    {
        private IAPILibrary _APIlib;
        private IHttpClientFactory _Clientfactory;
        public HistoryController(IAPILibrary APIlib, IHttpClientFactory Clientfactory)
        {
            _APIlib = APIlib;
            _Clientfactory = Clientfactory;
        }
        public async Task<IActionResult> List()
        {
            List<API.Models.HistoryDataModel> Historydata = await _APIlib.GetHistory(_Clientfactory);
            List<Models.HistoryViewModel> list = new List<Models.HistoryViewModel>();
            foreach (API.Models.HistoryDataModel Item in Historydata)
            {
                list.Add(new Models.HistoryViewModel() { Salary = Item.Salary,  TaxType = Item.TaxType, DateTime = Item.DateTime, TaxAmount =Item.TaxAmount });
            }
            return View(list);
        }
    }
}
