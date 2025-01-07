using PortfolioWpf.Data;
using PortfolioWpf.ViewModels;
using System.Collections.ObjectModel;

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

            return ip;
        }
    }
}