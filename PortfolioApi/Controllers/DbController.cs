using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Model;
using Portfolio.Api;

namespace Portfolio.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class DbController : ControllerBase
    {
        public DbSet<LoremIpsum> LoremIpsums { get; set; }

        private readonly IConfiguration _configuration;

        public DbController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet, Route("/api/Ipsums")]
        public IEnumerable<LoremIpsum> Ipsums()
        {
            using (var db = new LoremIpsumContext(_configuration))
            {
                var ipsums = db.LoremIpsums.AsNoTracking().ToList();

                return ipsums;
            }
        }
    }
}