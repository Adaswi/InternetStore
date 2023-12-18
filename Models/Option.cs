using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Option
{
    public decimal OptionId { get; set; }

    public decimal OptionPackId { get; set; }

    public string OptionName { get; set; } = null!;

    public decimal? OptionPrice { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual OptionPack OptionPack { get; set; } = null!;
}
