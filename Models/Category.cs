using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Category
{
    public decimal CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
