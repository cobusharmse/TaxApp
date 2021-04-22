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
    public class FlatRateTaxTableController : ControllerBase
    {
        private IConfiguration _Config;
        private DataLib.Interface.IDataBaseInterface _DB;
        public FlatRateTaxTableController(IConfiguration cnf, DataLib.Interface.IDataBaseInterface DB)
        {
            _Config = cnf;
            _DB = DB;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Models.FlatRateTaxDataModel))]
        [SwaggerOperation(Tags = new[] { "FlatRateTaxTable" }, OperationId = "GetAllTaxtableEntries")]
        public IActionResult GetTaxTable()
        {

            List<Models.FlatRateTaxDataModel> retVal = new List<Models.FlatRateTaxDataModel>();
            List<DataLib.Models.FlatRateTaxDataModel> Dbval = _DB.ListFlatRateTax(_Config.GetConnectionString("TaxApp"));
            foreach (DataLib.Models.FlatRateTaxDataModel Item in Dbval)
            {
                retVal.Add(new Models.FlatRateTaxDataModel() {Rate =Item.Rate });
            }

            return Ok(retVal.FirstOrDefault());
        }
    }
}
