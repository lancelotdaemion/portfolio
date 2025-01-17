using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
    public static class GraphQlFunctions
    {
        [FunctionName("GraphQL")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var server = new Server();
            string query = req.Query["query"];
            // string query = "mutation test { addJedi(input: { name: \"JarJar\", side: \"Dark\"  }) { name } }";

            var json = await server.QueryAsync(query);
            return new OkObjectResult(json);
        }
    }
}
