using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace FunctionApp1
{
    public static class QueueFunctions
    {
        [FunctionName("LoremIpsumChange")]
        public static void LoremIpsumChange([ServiceBusTrigger("portfolio", Connection = "sbConn")] string queueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {queueItem}");

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
                        dbIpsumToEdit.PreviousValue = ipsum.PreviousValue;
                        dbIpsumToEdit.PercentageChange = ipsum.PercentageChange;

                        break;
                    case LoremIpsumType.Delete:
                        var dbIpsumToDelete = db.LoremIpsums.Where(li => li.Id == ipsum.Id).Single();

                        db.LoremIpsums.Remove(dbIpsumToDelete);

                        break;
                    case LoremIpsumType.DeleteAll:
                        db.Database.ExecuteSql(FormattableStringFactory.Create("TRUNCATE TABLE dbo.LoremIpsums"));

                        break;
                }

                db.SaveChanges();
            }

            //return new OkObjectResult(null);
        }
    }
}
