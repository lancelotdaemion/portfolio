using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace PortfolioFunction
{
    public class PortfolioFunctions
    {
        private readonly ILogger _logger;
        private readonly ServiceBusContext _context;

        public PortfolioFunctions(ILoggerFactory loggerFactory, ServiceBusContext context)
        {
            _logger = loggerFactory.CreateLogger<PortfolioFunctions>();
            _context = context; 
        }

        [Function("PortfolioFunctions")]
        public void Run([ServiceBusTrigger("portfolio", Connection = "")] string myQueueItem)
        {
            _logger.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
