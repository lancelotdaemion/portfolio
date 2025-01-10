using Azure.Messaging.ServiceBus;
using PortfolioWpf.Data;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PortfolioWpf.Services
{
    public interface IQueueService
    {
        Task AddIpsum(Data.LoremIpsum ipsum);
        Task UpdateIpsum(Data.LoremIpsum ipsum);
        Task DeleteIpsum(Data.LoremIpsum ipsum);
        Task DeleteAll();
    }

    public class QueueService : IQueueService
    {
        private readonly ServiceBusContext _context;
        private JsonSerializerOptions _jsonOptions = new() { WriteIndented = false };

        public QueueService(ServiceBusContext context)
        {
            _context = context;
        }

        public async Task AddIpsum(Data.LoremIpsum ipsum) 
        {
            ipsum.Type = LoremIpsumType.Add;

            ipsum.PreviousValue = ipsum.Value;
            ipsum.PercentageChange = 0;

            await Send(ipsum);
        }

        public async Task UpdateIpsum(Data.LoremIpsum ipsum)
        {
            ipsum.Type = LoremIpsumType.Edit;            

            ipsum.PercentageChange = ((ipsum.Value - ipsum.PreviousValue) / Math.Abs(ipsum.PreviousValue)) * 100;

            ipsum.PreviousValue = ipsum.Value;

            await Send(ipsum);
        }

        public async Task DeleteIpsum(Data.LoremIpsum ipsum)
        {
            ipsum.Type = LoremIpsumType.Delete;

            await Send(ipsum);
        }

        public async Task DeleteAll()
        {
            var ipsum = new Data.LoremIpsum();

            ipsum.Type = LoremIpsumType.DeleteAll;

            await Send(ipsum);
        }

        private async Task Send(Data.LoremIpsum ipsum)
        {
            await using var client = new ServiceBusClient(_context.ConnectionString);

            var sender = client.CreateSender(_context.QueueName);

            var json = JsonSerializer.Serialize(ipsum, _jsonOptions);

            var message = new ServiceBusMessage(json);

            await sender.SendMessageAsync(message);
        }
    }
}