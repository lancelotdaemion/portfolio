using Azure.Messaging.ServiceBus;
using PortfolioWpf.Data;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PortfolioWpf.Services
{
    public interface IAzureService
    {
        Task SendLoremIpsum(Data.LoremIpsum ipsum);
    }

    public class AzureService : IAzureService
    {
        private readonly ServiceBusContext _context;
        private JsonSerializerOptions _jsonOptions = new() { WriteIndented = false };

    public AzureService (ServiceBusContext context)
        {
            _context = context;
        }

        public async Task SendLoremIpsum(Data.LoremIpsum ipsum) 
        {
            await using var client = new ServiceBusClient(_context.ConnectionString);

            var sender = client.CreateSender(_context.QueueName);

            var json = JsonSerializer.Serialize(ipsum, _jsonOptions);

            var message = new ServiceBusMessage(json);

            await sender.SendMessageAsync(message);
        }
    }
}