using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Model;

namespace PortfolioApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ODataController : Microsoft.AspNetCore.OData.Routing.Controllers.ODataController
    {
        // https://localhost:7055/odata/Ipsums
        // https://localhost:7055/odata/odata/$metadata
        [EnableQuery, HttpGet, Route("/odata/Ipsums")]
        public ActionResult<IEnumerable<LoremIpsum>> Get()
        {
            using (var db = new LoremIpsumContext())
            {
                var ipsums = db.LoremIpsums.AsNoTracking().ToList();

                return Ok(ipsums);
            }
        }
    }
}