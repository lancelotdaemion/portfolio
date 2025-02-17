﻿using System;

namespace Portfolio.Web
{
    public enum LoremIpsumType
    {
        Add = 0,
        Edit = 1,
        Delete = 2,
        DeleteAll = 3
    }

    public class LoremIpsum
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal PreviousValue { get; set; }
        public decimal PercentageChange { get; set; }
        public LoremIpsumType Type { get; set; }

        public override string ToString() => Name;
    }
}