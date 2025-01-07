using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using PortfolioFunctions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text.Json;

namespace PortfolioFunction
{
    public class PortfolioFunctions
    {
        private readonly ILogger _logger;
        //private readonly ServiceBusContext _servicebusContext;
        //private readonly LoremIpsumContext _loremIpsumContext;

        public PortfolioFunctions(ILoggerFactory loggerFactory, ServiceBusContext servicebusContext, LoremIpsumContext loremIpsumContext)
        {
            _logger = loggerFactory.CreateLogger<PortfolioFunctions>();
            //_servicebusContext = servicebusContext;
            //_loremIpsumContext = loremIpsumContext;
        }

        [Function("PortfolioFunctions")]
        public void Run([ServiceBusTrigger("portfolio", Connection = "")] string queueItem)
        {
            _logger.LogInformation($"C# ServiceBus queue trigger function processed message: {queueItem}");

            var ipsum = JsonSerializer.Deserialize<LoremIpsum>(queueItem);

            using (var db = new LoremIpsumContext())
            {
                switch (ipsum.Type)
                {
                    case LoremIpsumType.Add:
                        db.LoremIpsums.Add(ipsum);

                        break;
                    case LoremIpsumType.Edit:
                        var dbIpsumToEdit = db.LoremIpsums.Where(li => li.Id == ipsum.Id).Single();

                        dbIpsumToEdit.Name = ipsum.Name;
                        dbIpsumToEdit.Value = ipsum.Value;

                        break;
                    case LoremIpsumType.Delete:
                        var dbIpsumToDelete = db.LoremIpsums.Where(li => li.Id == ipsum.Id).Single();

                        db.LoremIpsums.Remove(dbIpsumToDelete);

                        break;
                    case LoremIpsumType.DeleteAll:
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.LoremIpsums");

                        break;
                }
                
                db.SaveChanges();
            }
        }
    }
}
