using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace FunctionApp1
{
    public static class SqlTriggerBinding
    {
        // Visit https://aka.ms/sqltrigger to learn how to use this trigger binding
        [FunctionName("SqlFunction")]
        public static void SqlFunction([SqlTrigger("[dbo].[LoremIpsums]", "sqlConn")] IReadOnlyList<SqlChange<LoremIpsum>> changes, ILogger log)
        {
            log.LogInformation("SQL Changes: " + JsonConvert.SerializeObject(changes));

        }
    }
}
