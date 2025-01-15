using CommunityToolkit.Mvvm.Input;
using PortfolioWpf.Model;
using System.Collections.ObjectModel;

namespace PortfolioWpf.ViewModels
{
    public partial class LoremIpsomViewModel
    {
        private string _currentIpsum;
        private LoremIpsum _selectedLoremIpsum;

        public string CurrentIpsumText { get => _currentIpsum; set => SetProperty(ref _currentIpsum, value); }

        public LoremIpsum SelectedLoremIpsum { get => _selectedLoremIpsum; set => SetProperty(ref _selectedLoremIpsum, value); }


        private ObservableCollection<LoremIpsum> _ipsums;
        public ObservableCollection<LoremIpsum> Ipsums { get => _ipsums; private set => SetProperty(ref _ipsums, value); }

        public IAsyncRelayCommand LoadIpsumsCommand => new AsyncRelayCommand(LoadIpsumsAsync);

        //private async Task LoadIpsumsAsync() => Ipsums = _dataService.GetIpsums();

        public IRelayCommand AddIpsumCommand => new RelayCommand(AddIpsum);
        public IRelayCommand EditIpsumCommand => new RelayCommand(UpdateIpsum);

        public IRelayCommand DeleteIpsumCommand => new RelayCommand(DeleteIpsum);
        public IRelayCommand DeleteAllCommand => new RelayCommand(DeleteAll);
    }
}