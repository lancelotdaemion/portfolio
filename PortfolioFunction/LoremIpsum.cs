using System;

namespace PortfolioFunction
{
    public enum LoremIpsumType
    {
        Add = 0,
        Edit = 1,
        Delete = 2
    }

    public class LoremIpsum
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public LoremIpsumType Type { get; set; }

        public override string ToString() => Name;
    }
}