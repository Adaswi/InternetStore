using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class ItemDTO
{
    public decimal? CartId { get; set; }

    public decimal ProductId { get; set; }

    public decimal? OrderId { get; set; }

    public decimal? OptionId { get; set; }

    public short ItemQuantity { get; set; }

    public decimal ItemPrice { get; set; }

    public bool ItemVisible { get; set; }
}
