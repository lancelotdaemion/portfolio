using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace PortfolioWpf.Data
{
    public class ServiceBusContext
    {
        private readonly SecretClient _client;

        public readonly string ConnectionString;
        public string Namespace => "lancelot";
        public string QueueName => "portfolio";

        public ServiceBusContext()
        {
            _client = new SecretClient(new System.Uri("https://lancelotkv.vault.azure.net/"), new DefaultAzureCredential());

            var secret = _client.GetSecret("queue", cancellationToken: new CancellationToken());

            ConnectionString = secret.Value.Value;
        }
    }
}
