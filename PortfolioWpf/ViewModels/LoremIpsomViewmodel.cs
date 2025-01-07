using CommunityToolkit.Mvvm.ComponentModel;
using PortfolioWpf.Services;

namespace PortfolioWpf.ViewModels
{
    public partial class LoremIpsomViewModel : ObservableRecipient
    {
        private readonly IDataService _dataService;
        private readonly IAzureService _azureBusService;

        public LoremIpsomViewModel(IDataService dataService, IAzureService azureBusService)
        {
            _dataService = dataService;
            _azureBusService = azureBusService;

            CurrentIpsumText = DefaultIpsomText();

            Ipsums = _dataService.GetIpsums();
        }

        private async Task LoadIpsumsAsync() => Ipsums = _dataService.GetIpsums();

        

        private string DefaultIpsomText()
        {
            var rand = new Random();

            var ipsumIndex = rand.Next(0, LoremIpsum.Collection.Values.Count - 1);

            return LoremIpsum.Collection.Values.ElementAt(ipsumIndex).Name;
        }



        private void AddIpsum()
        {
            var newIpsum = _dataService.AddIpsum(CurrentIpsumText);

            Ipsums.Add(new Data.LoremIpsum { Id = newIpsum.Id, Name = newIpsum.Name });

            CurrentIpsumText = DefaultIpsomText();

            _azureBusService.AddIpsum(newIpsum);
        }

        private void UpdateIpsum() => _azureBusService.UpdateIpsum(SelectedLoremIpsum);

        private void DeleteIpsum()
        {
            _azureBusService.DeleteIpsum(SelectedLoremIpsum);

            Ipsums.Remove(SelectedLoremIpsum);
        }

        private void DeleteAll()
        {
            _azureBusService.DeleteAll();

            Ipsums.Clear();
        }
    }
}