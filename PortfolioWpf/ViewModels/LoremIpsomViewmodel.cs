using CommunityToolkit.Mvvm.ComponentModel;
using PortfolioWpf.Services;

namespace PortfolioWpf.ViewModels
{
    public partial class LoremIpsomViewModel : ObservableRecipient
    {
        private readonly IDataService _dataService;
        private readonly IQueueService _queueService;

        public LoremIpsomViewModel(IDataService dataService, IQueueService azureQueueService)
        {
            _dataService = dataService;
            _queueService = azureQueueService;

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

            Ipsums.Add(new Data.LoremIpsum { Id = newIpsum.Id, Name = newIpsum.Name, Value = newIpsum.Value });

            CurrentIpsumText = DefaultIpsomText();

            _queueService.AddIpsum(newIpsum);
        }

        private void UpdateIpsum() => _queueService.UpdateIpsum(SelectedLoremIpsum);

        private void DeleteIpsum()
        {
            _queueService.DeleteIpsum(SelectedLoremIpsum);

            Ipsums.Remove(SelectedLoremIpsum);
        }

        private void DeleteAll()
        {
            _queueService.DeleteAll();

            Ipsums.Clear();
        }
    }
}