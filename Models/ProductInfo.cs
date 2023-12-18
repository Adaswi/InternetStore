using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class ProductInfo
{
    public decimal ProductInfoId { get; set; }

    public decimal ProductId { get; set; }

    public int ProductInfoQuantity { get; set; }

    public DateTime ProductInfoDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
