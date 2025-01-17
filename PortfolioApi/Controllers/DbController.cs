using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Model;
using Portfolio.Api;

namespace Portfolio.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class DbController : ControllerBase
    {
        [HttpGet, Route("/api/Ipsums")]
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