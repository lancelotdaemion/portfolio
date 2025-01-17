using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Portfolio.Model;
using System.Threading;

namespace Portfolio.Functions
{
    public class LoremIpsumContext : DbContext
    {
        public DbSet<LoremIpsum> LoremIpsums { get; set; }

        private readonly SecretClient _client;

        public LoremIpsumContext()
        {
            _client = new SecretClient(new System.Uri("https://lancelotkv.vault.azure.net/"), new DefaultAzureCredential());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseAzureSql( "Data Source=products.db");
            //optionsBuilder.UseLazyLoadingProxies();

            var secret = _client.GetSecret("sql", cancellationToken: new CancellationToken());

            optionsBuilder.UseSqlServer(secret.Value.Value);
        }
    }
}
