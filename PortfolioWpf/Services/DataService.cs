using Microsoft.Azure.Amqp.Framing;
using PortfolioWpf.Data;
using PortfolioWpf.ViewModels;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Windows.Controls;
using static Microsoft.Azure.Amqp.Serialization.SerializableType;

namespace PortfolioWpf.Services
{
    public interface IDataService
    {
        ObservableCollection<Data.LoremIpsum> GetIpsums();
        Data.LoremIpsum AddIpsum(string ipsum);
    }

    public class DataService : IDataService
    {
        private readonly LoremIpsumContext _context;

        public DataService(LoremIpsumContext context)
        {
            _context = context;
        }

        public ObservableCollection<Data.LoremIpsum> GetIpsums()
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;

            var rand = new Random();

            var ipsums = _context.LoremIpsums;

            return new ObservableCollection<Data.LoremIpsum>(ipsums);
        }

        public Data.LoremIpsum AddIpsum(string ipsum)
        {
            var ip = new Data.LoremIpsum {  Id = Guid.NewGuid(), Name = ipsum };

            var random = new Random();

            var doub = random.NextDouble() * (10000 - 0) + 0;

            var dec = Convert.ToDecimal(doub);

            ip.Value = Math.Round(dec, 2);
            ip.PreviousValue = ip.Value;

            return ip;
        }
    }
}