using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWpf.ViewModels
{
    internal class LoremIpsomViewModel
    {
        public string CurrentIpsum { get; set; }

        public List<string> Ipsums { get; set; } = new List<string>();

        public LoremIpsomViewModel(string currentIpsum)
        {
            CurrentIpsum = currentIpsum;
        }
    }
}
