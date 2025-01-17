using PortfolioWpf.Data;
using Portfolio.Model;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace PortfolioWpf.Services
{
    public interface IDataService
    {
        Task<ObservableCollection<LoremIpsum>> GetIpsums();
        LoremIpsum AddIpsum(string ipsum);
    }

    public class DataService : IDataService
    {
        private readonly SecretClient _client;

        public DataService() 
        {
            _client = new SecretClient(new System.Uri("https://lancelotkv.vault.azure.net/"), new DefaultAzureCredential());
        }


        public async Task<ObservableCollection<LoremIpsum>> GetIpsums()
        {
            ObservableCollection<LoremIpsum> ipsums = null;

            var secret = _client.GetSecret("api", cancellationToken: new CancellationToken());

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(secret.Value.Value))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    ipsums = JsonSerializer.Deserialize<ObservableCollection<LoremIpsum>>(apiResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    //ipsums = new ObservableCollection<LoremIpsum>(results);
                }
            }

            return ipsums;
        }

        public LoremIpsum AddIpsum(string ipsum)
        {
            var ip = new LoremIpsum {  Id = Guid.NewGuid(), Name = ipsum };

            var random = new Random();

            var doub = random.NextDouble() * (10000 - 0) + 0;

            var dec = Convert.ToDecimal(doub);

            ip.Value = Math.Round(dec, 2);
            ip.PreviousValue = ip.Value;

            return ip;
        }
    }
}