using PortfolioWpf.ViewModels;
using System.Windows;

namespace PortfolioWpf
{
    public partial class MainWindow : Window
    {
        private readonly LoremIpsomViewModel _viewmodel;

        public MainWindow()
        {
            InitializeComponent();

            _viewmodel = new LoremIpsomViewModel(DefaultIpsom()); 
            DataContext = _viewmodel;

            //LoadIpsum();
        }

        private string DefaultIpsom()
        {
            var rand = new Random();

            var ipsumIndex = rand.Next(0, LoremIpsum.Collection.Values.Length - 1);

            return LoremIpsum.Collection.Values[ipsumIndex];
        }
    }
}   