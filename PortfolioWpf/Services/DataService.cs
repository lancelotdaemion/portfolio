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
        public T GetValue<T>(string key)
        {
            return default;
        }

        public void SetValue<T>(string key, T value)
        {
            //throw new NotImplementedException();
        }
    }
}
