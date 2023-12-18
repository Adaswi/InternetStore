using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class OptionPack
{
    public decimal OptionPackId { get; set; }

    public decimal ProductId { get; set; }

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
