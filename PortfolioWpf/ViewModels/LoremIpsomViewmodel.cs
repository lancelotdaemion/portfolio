using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PortfolioWpf.LoremIpsum;

namespace PortfolioWpf.ViewModels
{
    public class LoremIpsomViewModel : ObservableRecipient
    {
        private readonly IDataService _dataService;

        private string _currentIpsum;

        public string CurrentIpsum { get => _currentIpsum; private set => SetProperty(ref _currentIpsum, value); }


        private Dictionary<Guid, string> _ipsums;
        public Dictionary<Guid, string> Ipsums { get => _ipsums; private set => SetProperty(ref _ipsums, value); }

        public IAsyncRelayCommand LoadIpsumsCommand => new AsyncRelayCommand(LoadIpsumsAsync);

        private async Task LoadIpsumsAsync() => Ipsums = _dataService.GetIpsums();

        public IRelayCommand AddIpsumCommand => new RelayCommand(AddIpsum);

        private async Task AddIpsumAsync() => AddIpsum();


        public LoremIpsomViewModel(IDataService dataService)
        {
            _dataService = dataService;

            CurrentIpsum = DefaultIpsom();

            Ipsums = _dataService.GetIpsums();
        }

        private void AddIpsum()
        {
            _dataService.AddIpsum(CurrentIpsum);

            CurrentIpsum = DefaultIpsom();

            Ipsums = _dataService.GetIpsums();
        }

        private string DefaultIpsom()
        {
            var rand = new Random();

            var ipsumIndex = rand.Next(0, LoremIpsum.Collection.Values.Count - 1);

            return LoremIpsum.Collection.Values.ElementAt(ipsumIndex).Value;
        }
    }
}