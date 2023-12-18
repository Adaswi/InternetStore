using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Cart
{
    public decimal CartId { get; set; }

    public decimal UserId { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual User User { get; set; } = null!;
}
