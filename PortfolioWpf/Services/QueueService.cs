using Azure.Messaging.ServiceBus;
using PortfolioWpf.Data;
using Portfolio.Model;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PortfolioWpf.Services
{
    public interface IQueueService
    {
        Task AddIpsum(LoremIpsum ipsum);
        Task UpdateIpsum(LoremIpsum ipsum);
        Task DeleteIpsum(LoremIpsum ipsum);
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

        public async Task AddIpsum(LoremIpsum ipsum) 
        {
            ipsum.Type = LoremIpsumType.Add;

            ipsum.PreviousValue = ipsum.Value;
            ipsum.PercentageChange = 0;

            await Send(ipsum);
        }

        public async Task UpdateIpsum(LoremIpsum ipsum)
        {
            ipsum.Type = LoremIpsumType.Edit;            

            ipsum.PercentageChange = ((ipsum.Value - ipsum.PreviousValue) / Math.Abs(ipsum.PreviousValue)) * 100;

            ipsum.PreviousValue = ipsum.Value;

            await Send(ipsum);
        }

        public async Task DeleteIpsum(LoremIpsum ipsum)
        {
            ipsum.Type = LoremIpsumType.Delete;            

            await Send(ipsum);
        }

        public async Task DeleteAll()
        {
            var ipsum = new LoremIpsum();

            ipsum.Type = LoremIpsumType.DeleteAll;
            ipsum.Name = "deleteall";

            await Send(ipsum);
        }

        private async Task Send(LoremIpsum ipsum)
        {
            await using var client = new ServiceBusClient(_context.ConnectionString);

            var sender = client.CreateSender(_context.QueueName);

            var json = JsonSerializer.Serialize(ipsum, _jsonOptions);

            var message = new ServiceBusMessage(json);

            await sender.SendMessageAsync(message);
        }
    }
}