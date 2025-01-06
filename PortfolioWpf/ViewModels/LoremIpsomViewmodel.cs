using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PortfolioWpf.LoremIpsum;

namespace PortfolioWpf.ViewModels
{
    public class LoremIpsomViewModel : ObservableRecipient
    {
        private readonly IDataService _dataService;

        private string _currentIpsum;

        public string CurrentIpsum
        {
            get => _currentIpsum;
            private set => SetProperty(ref _currentIpsum, value);
        }

        public Dictionary<Guid, string> Ipsums { get; set; } = new Dictionary<Guid, string>();

        public IAsyncRelayCommand LoadCurrentIpsumCommand => new AsyncRelayCommand(LoadCurrentIpsumAsync);



        public LoremIpsomViewModel(IDataService dataService)
        {
            _dataService = dataService;

            CurrentIpsum = DefaultIpsom();
            Ipsums = LoremIpsum.Collection.Values;
        }

        private async Task LoadCurrentIpsumAsync() => Ipsums = Collection.Values;

        private string DefaultIpsom()
        {
            var rand = new Random();

            var ipsumIndex = rand.Next(0, LoremIpsum.Collection.Values.Count - 1);

            return LoremIpsum.Collection.Values.ElementAt(ipsumIndex).Value;
        }
    }
}