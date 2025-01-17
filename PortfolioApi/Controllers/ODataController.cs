using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfolio.Model;

namespace Portfolio.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ODataController : Microsoft.AspNetCore.OData.Routing.Controllers.ODataController
    {
        private readonly IConfiguration _configuration;

        public ODataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // https://localhost:7055/odata/Ipsums
        // https://localhost:7055/odata/odata/$metadata
        [EnableQuery, HttpGet, Route("/odata/Ipsums")]
        public ActionResult<IEnumerable<LoremIpsum>> Get()
        {
            using (var db = new LoremIpsumContext(_configuration))
            {
                var ipsums = db.LoremIpsums.AsNoTracking().ToList();

                return Ok(ipsums);
            }
        }
    }
}