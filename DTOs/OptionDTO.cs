using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class OptionDTO
{
    public decimal OptionId { get; set; }

    public decimal OptionPackId { get; set; }

    public string OptionName { get; set; } = null!;

    public decimal? OptionPrice { get; set; }

}
