using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Portfolio.Model;
using Portfolio.Api.Hubs;

namespace Portfolio.Api.Controllers
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