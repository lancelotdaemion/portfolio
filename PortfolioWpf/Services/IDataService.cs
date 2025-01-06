using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace PortfolioWpf.ViewModels
{
    public interface IDataService
    {
        ObservableCollection<Data.LoremIpsum> GetIpsums();
        Data.LoremIpsum AddIpsum(string ipsum);
    }
}