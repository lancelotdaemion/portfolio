﻿using Azure.Messaging.ServiceBus;
using PortfolioWpf.Data;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PortfolioWpf.Services
{
    public interface IAzureService
    {
        Task AddIpsum(Data.LoremIpsum ipsum);
        Task UpdateIpsum(Data.LoremIpsum ipsum);
        Task DeleteIpsum(Data.LoremIpsum ipsum);
        Task DeleteAll();
    }

    public class AzureService : IAzureService
    {
        private readonly ServiceBusContext _context;
        private JsonSerializerOptions _jsonOptions = new() { WriteIndented = false };

        public AzureService (ServiceBusContext context)
        {
            _context = context;
        }

        public async Task AddIpsum(Data.LoremIpsum ipsum) 
        {
            ipsum.Type = LoremIpsumType.Add;

            await Send(ipsum);
        }

        public async Task UpdateIpsum(Data.LoremIpsum ipsum)
        {
            ipsum.Type = LoremIpsumType.Edit;

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