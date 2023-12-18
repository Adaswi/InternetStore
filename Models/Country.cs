﻿using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Country
{
    public decimal CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
