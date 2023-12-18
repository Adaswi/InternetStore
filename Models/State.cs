using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class State
{
    public decimal StateId { get; set; }

    public decimal? CountryId { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? Country { get; set; }
}
