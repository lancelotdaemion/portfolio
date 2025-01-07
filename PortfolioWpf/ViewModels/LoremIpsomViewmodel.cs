using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PortfolioWpf.Data;
using PortfolioWpf.LoremIpsum;
using PortfolioWpf.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PortfolioWpf.ViewModels
{
    public class LoremIpsomViewModel : ObservableRecipient
    {
        private readonly IDataService _dataService;
        private readonly IAzureService _azureBusService;

        private string _currentIpsum;

        public string CurrentIpsum { get => _currentIpsum; private set => SetProperty(ref _currentIpsum, value); }


        private ObservableCollection<Data.LoremIpsum> _ipsums;
        public ObservableCollection<Data.LoremIpsum> Ipsums { get => _ipsums; private set => SetProperty(ref _ipsums, value); }

        public IAsyncRelayCommand LoadIpsumsCommand => new AsyncRelayCommand(LoadIpsumsAsync);

        private async Task LoadIpsumsAsync() => Ipsums = _dataService.GetIpsums();

        public IRelayCommand AddIpsumCommand => new RelayCommand(AddIpsum);

        private async Task AddIpsumAsync() => AddIpsum();


        public LoremIpsomViewModel(IDataService dataService, IAzureService azureBusService)
        {
            _dataService = dataService;
            _azureBusService = azureBusService;

            CurrentIpsum = DefaultIpsom();

            Ipsums = _dataService.GetIpsums();
        }

        private void AddIpsum()
        {
            var newipsum = _dataService.AddIpsum(CurrentIpsum);

            Ipsums.Add(new Data.LoremIpsum { Id = newipsum.Id, Name = newipsum.Name });

            CurrentIpsum = DefaultIpsom();

            _azureBusService.SendLoremIpsum(newipsum);
        }

        private string DefaultIpsom()
        {
            var rand = new Random();

            var ipsumIndex = rand.Next(0, LoremIpsum.Collection.Values.Count - 1);

            return LoremIpsum.Collection.Values.ElementAt(ipsumIndex).Name;
        }
    }
}