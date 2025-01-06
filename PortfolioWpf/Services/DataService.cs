using PortfolioWpf.Data;
using PortfolioWpf.ViewModels;
using System;
using System.Collections.Generic;
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

            // this is for demo purposes only, to make it easier
            // to get up and running
            //_context.Database.EnsureCreated();

            // load the entities into EF Core
            //_context.LoremIpsums..Load();

        }

        public T GetValue<T>(string key)
        {
            return default;
        }

        public void SetValue<T>(string key, T value)
        {
            //throw new NotImplementedException();
        }

        public Dictionary<Guid, string> GetIpsums()
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;

            var ipsums = _context.LoremIpsums.ToDictionary(li => li.Id, li => li.Name);

            if (ipsums.Count == 0)
                ipsums = LoremIpsum.Collection.Values;

            return ipsums;
        }
    }
}
