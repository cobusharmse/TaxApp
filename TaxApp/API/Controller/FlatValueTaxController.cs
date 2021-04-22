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
    public class FlatValueTaxTableController : ControllerBase
    {
        private IConfiguration _Config; 
        private DataLib.Interface.IDataBaseInterface _DB;
        public FlatValueTaxTableController(IConfiguration cnf, DataLib.Interface.IDataBaseInterface DB)
        {
            _Config = cnf;
            _DB = DB;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Models.FlatValueTaxDataModel))]
        [SwaggerOperation(Tags = new[] { "FlatValueTaxTable" }, OperationId = "GetAllTaxtableEntries")]
        public IActionResult GetTaxTable()
        {
     
            List<Models.FlatValueTaxDataModel> retVal = new List<Models.FlatValueTaxDataModel>();
            List<DataLib.Models.FlatValueTaxDataModel> Dbval = _DB.ListFlatValueTax(_Config.GetConnectionString("TaxApp"));
            foreach (DataLib.Models.FlatValueTaxDataModel Item in Dbval)
            {
                retVal.Add(new Models.FlatValueTaxDataModel() { Rate = Item.Rate, Value = Item.Value, MinValue = Item.MinValue });
            }

            return Ok(retVal.FirstOrDefault());
        }
    }
}
