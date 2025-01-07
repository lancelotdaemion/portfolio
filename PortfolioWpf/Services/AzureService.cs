using Azure.Messaging.ServiceBus;
using PortfolioWpf.Data;

namespace PortfolioWpf.Services
{
    public interface IAzureService
    {
        Task SendLoremIpsum(Data.LoremIpsum ipsum);
    }

    public class AzureService : IAzureService
    {
        private readonly ServiceBusContext _context;

        public AzureService (ServiceBusContext context)
        {
            _context = context;
        }

        public async Task SendLoremIpsum(Data.LoremIpsum ipsum) 
        {
            await using var client = new ServiceBusClient(_context.ConnectionString);

            ServiceBusSender sender = client.CreateSender(_context.QueueName);

            ServiceBusMessage message = new ServiceBusMessage("Hello world! ");

            await sender.SendMessageAsync(message);
        }
    }
}
