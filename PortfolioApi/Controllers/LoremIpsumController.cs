using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Hubs;

namespace PortfolioApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class LoremIpsumController : ControllerBase
    {
        private readonly IHubContext<LoremIpsumHub, ILoremIpsumClient> _context;

        public LoremIpsumController(IHubContext<LoremIpsumHub, ILoremIpsumClient> context)
        {
            _context = context;
        }

        [HttpGet, Route("/api/Ipsums")]
        public IEnumerable<LoremIpsum> Ipsums()
        {
            using (var db = new LoremIpsumContext())
            {
                var ipsums = db.LoremIpsums.AsNoTracking().ToList();

                return ipsums;
            }
        }

        [HttpPost, Route("/api/IpsumChanged")]
        public void IpsumChanged(LoremIpsum ipsum) => _context.Clients.All.ReceivedNotification(ipsum);
    }
}