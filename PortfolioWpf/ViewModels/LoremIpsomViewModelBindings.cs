using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace PortfolioWpf.ViewModels
{
    public partial class LoremIpsomViewModel
    {
        private string _currentIpsum;
        private Data.LoremIpsum _selectedLoremIpsum;

        public string CurrentIpsumText { get => _currentIpsum; private set => SetProperty(ref _currentIpsum, value); }

        public Data.LoremIpsum SelectedLoremIpsum { get => _selectedLoremIpsum; set => SetProperty(ref _selectedLoremIpsum, value); }


        private ObservableCollection<Data.LoremIpsum> _ipsums;
        public ObservableCollection<Data.LoremIpsum> Ipsums { get => _ipsums; private set => SetProperty(ref _ipsums, value); }

        public IAsyncRelayCommand LoadIpsumsCommand => new AsyncRelayCommand(LoadIpsumsAsync);

        //private async Task LoadIpsumsAsync() => Ipsums = _dataService.GetIpsums();

        public IRelayCommand AddIpsumCommand => new RelayCommand(AddIpsum);
        public IRelayCommand EditIpsumCommand => new RelayCommand(UpdateIpsum);

        public IRelayCommand DeleteIpsumCommand => new RelayCommand(DeleteIpsum);
    }
}