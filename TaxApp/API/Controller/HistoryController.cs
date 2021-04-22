using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Extensions.Logging;

namespace TaxApp.API.Controllers
{
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private IConfiguration _Config;
        private DataLib.Interface.IDataBaseInterface _DB;
        public HistoryController(IConfiguration cnf, DataLib.Interface.IDataBaseInterface DB)
        {
            _Config = cnf;
            _DB = DB;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Models.HistoryDataModel>))]
        [SwaggerOperation(Tags = new[] { "History" }, OperationId = "GetAllHistory")]
        public IActionResult GetHistory()
        {
            List<Models.HistoryDataModel> retVal = new List<Models.HistoryDataModel>();
            List<DataLib.Models.HistoryDataModel> Dbval = _DB.ListHistory(_Config.GetConnectionString("TaxApp"));
            foreach(DataLib.Models.HistoryDataModel Item in Dbval)
            {
                retVal.Add(new Models.HistoryDataModel() { DateTime = Item.DateTime, Salary = Item.Salary, TaxAmount = Item.TaxAmount, TaxType = Item.TaxType });
            }
            return Ok(retVal);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200)]
        [SwaggerOperation(Tags = new[] { "History" }, OperationId = "AddHistory")]
        public IActionResult AddHistory([FromBody] Models.HistoryDataModel Data)
        {
            _DB.SaveHistory(Data.Salary, Data.TaxAmount, Data.TaxType, _Config.GetConnectionString("TaxApp"));
            return Ok();
        }
    }
}
