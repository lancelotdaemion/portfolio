using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Portfolio.Api.Model;
using PortfolioApi.Hubs;

namespace PortfolioApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class SignalRController : ControllerBase
    {
        private readonly IHubContext<LoremIpsumHub, ILoremIpsumClient> _context;

        public SignalRController(IHubContext<LoremIpsumHub, ILoremIpsumClient> context)
        {
            _context = context;
        }

        [HttpPost, Route("/api/IpsumChanged")]
        public void IpsumChanged(LoremIpsum ipsum) => _context.Clients.All.ReceivedNotification(ipsum);
    }
}