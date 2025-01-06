using PortfolioWpf.Services;
using PortfolioWpf.ViewModels;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace PortfolioWpf
{
    public partial class MainWindow : Window
    {

        public LoremIpsomViewModel ViewModel => (LoremIpsomViewModel)DataContext;

        public MainWindow(LoremIpsomViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}   