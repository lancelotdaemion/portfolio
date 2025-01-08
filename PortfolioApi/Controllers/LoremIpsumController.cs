using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class LoremIpsumController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<LoremIpsum> Ipsums()
        {
            using (var db = new LoremIpsumContext())
            {
                var ipsums = db.LoremIpsums.AsNoTracking().ToList();

                return ipsums;
            }
        }
    }
}