using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class City
{
    public decimal CityId { get; set; }

    public decimal? StateId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();

    public virtual State? State { get; set; }
}
