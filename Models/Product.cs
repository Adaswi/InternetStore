using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Product
{
    public decimal ProductId { get; set; }

    public decimal UserId { get; set; }

    public decimal? CategoryId { get; set; }

    public decimal? OptionPackId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public decimal ProductPrice { get; set; }

    public int ProductQuantity { get; set; }

    public bool ProductVisibility { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual OptionPack? OptionPack { get; set; }

    public virtual ICollection<OptionPack> OptionPacks { get; set; } = new List<OptionPack>();

    public virtual ICollection<ProductInfo> ProductInfos { get; set; } = new List<ProductInfo>();

    public virtual User User { get; set; } = null!;
}
