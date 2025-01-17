using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Portfolio.Functions.GraphQl
{
    public static class GraphQlFunctions
    {
        [FunctionName("GraphQL")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            var server = new Server();

            var query = req.Query["query"];
            // string query = "mutation test { addJedi(input: { name: \"JarJar\", side: \"Dark\"  }) { name } }";

            var json = await server.QueryAsync(query);

            return new OkObjectResult(json);
        }
    }
}