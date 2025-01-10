using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio.Functions
{
    public static class QueueFunctions
    {
        [FunctionName("LoremIpsumChange")]
        public static async Task LoremIpsumChange([ServiceBusTrigger("portfolio", Connection = "sbConn")] string queueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {queueItem}");

            var ipsum = System.Text.Json.JsonSerializer.Deserialize<LoremIpsum>(queueItem);

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

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(queueItem, Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7055/api/IpsumChanged", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }

            //return new OkObjectResult(null);
        }
    }
}
