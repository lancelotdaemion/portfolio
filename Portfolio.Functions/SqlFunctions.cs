using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;

namespace Portfolio.Functions
{
    public static class SqlTriggerBinding
    {
        [FunctionName("SqlChange")]
        public static void SqlChange([SqlTrigger("[dbo].[LoremIpsums]", "sqlConn")] IReadOnlyList<SqlChange<LoremIpsum>> changes, ILogger log)
        {
            log.LogInformation("SQL Changes: " + JsonSerializer.Serialize(changes));

        }
    }
}
