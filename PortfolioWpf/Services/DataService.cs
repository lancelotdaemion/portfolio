using PortfolioWpf.Data;
using PortfolioWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWpf.Services
{
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

            //if (ipsums.Count() == 0)
            //    ipsums = LoremIpsum.Collection.Values.OrderBy(x => rand.Next()).ToList();

            return new ObservableCollection<Data.LoremIpsum>(ipsums);
        }

        public Data.LoremIpsum AddIpsum(string ipsum)
        {
            var ip = new Data.LoremIpsum {  Id = Guid.NewGuid(), Name = ipsum };

            // send queue message

            _context.Add(ip);

            _context.SaveChanges();

            return ip;

            
        }
    }
}
