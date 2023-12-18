using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Item
{
    public decimal ItemId { get; set; }

    public decimal? CartId { get; set; }

    public decimal ProductId { get; set; }

    public decimal? OrderId { get; set; }

    public decimal? OptionId { get; set; }

    public short ItemQuantity { get; set; }

    public decimal ItemPrice { get; set; }

    public bool ItemVisible { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Option? Option { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product Product { get; set; } = null!;
}
