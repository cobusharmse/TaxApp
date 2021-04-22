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
    public class PostalCodeController : ControllerBase
    {
        private IConfiguration _Config;
        public PostalCodeController(IConfiguration cnf)
        {
            _Config = cnf;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Models.PostalCodeDataModel>))]
        [SwaggerOperation(Tags = new[] { "PostalCodes" }, OperationId = "GetAllPostalCodes")]
        public IActionResult GetPostalCodes()
        {
            List<Models.PostalCodeDataModel> retval = new List<Models.PostalCodeDataModel>();
            retval.Add(new Models.PostalCodeDataModel() { PostalCodeDescription = "7441", PostalCodeValue = "Progressive" });
            retval.Add(new Models.PostalCodeDataModel() { PostalCodeDescription = "A100", PostalCodeValue = "FlatValue" });
            retval.Add(new Models.PostalCodeDataModel() { PostalCodeDescription = "7000", PostalCodeValue = "Flatrate" });
            retval.Add(new Models.PostalCodeDataModel() { PostalCodeDescription = "1000", PostalCodeValue = "Progressive" });
            return Ok(retval);
        }
    }
}
