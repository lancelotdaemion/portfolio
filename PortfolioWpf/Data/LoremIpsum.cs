using CommunityToolkit.Mvvm.ComponentModel;

namespace PortfolioWpf.Data
{
    public enum LoremIpsumType
    {
        Add = 0,
        Edit = 1,
        Delete = 2,
        DeleteAll = 3
    }

    public partial class LoremIpsum : ObservableObject
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public decimal Value { get; set; }
        public LoremIpsumType Type { get; set; }

        public override string ToString() => Name;
    }
}