using Microsoft.AspNetCore.SignalR;

namespace PortfolioApi.Hubs
{
    public class LoremIpsumHub : Hub<ILoremIpsumClient>
    {
        public override async Task OnConnectedAsync()
        {
            //await Clients.Clients(Context.ConnectionId).ReceivedNotification(new LoremIpsum { Name = "dfsfdsfs" });

            await base.OnConnectedAsync();
        }
    }
}