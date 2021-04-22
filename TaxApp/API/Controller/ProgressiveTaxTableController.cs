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
    public class ProgressiveTaxTableController : ControllerBase
    {
        private IConfiguration _Config;
        private DataLib.Interface.IDataBaseInterface _DB;
        public ProgressiveTaxTableController(IConfiguration cnf, DataLib.Interface.IDataBaseInterface DB)
        {
            _Config = cnf;
            _DB = DB;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Models.ProgressiveTaxTableDataModel>))]
        [SwaggerOperation(Tags = new[] { "ProgessiveTaxTable" }, OperationId = "GetAllTaxtableEntries")]
        public IActionResult GetTaxTable()
        {
            List<Models.ProgressiveTaxTableDataModel> retVal = new List<Models.ProgressiveTaxTableDataModel>();
            List<DataLib.Models.ProgressiveTaxTableDataModel> Dbval = _DB.ListProGressiveTax(_Config.GetConnectionString("TaxApp"));
            foreach (DataLib.Models.ProgressiveTaxTableDataModel Item in Dbval)
            {
                retVal.Add(new Models.ProgressiveTaxTableDataModel() { Rate = Item.Rate, From = Item.From, To = Item.To });
            }
            return Ok(retVal);

        }
    }
}
