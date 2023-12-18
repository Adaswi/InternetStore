using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Adress
{
    public decimal AdressId { get; set; }

    public decimal? CityId { get; set; }

    public decimal UserId { get; set; }

    public string AdressField1 { get; set; } = null!;

    public string? AdressField2 { get; set; }

    public string AdressPostalCode { get; set; } = null!;

    public string AdressName { get; set; } = null!;

    public string AdressSurname { get; set; } = null!;

    public string AdressPhone { get; set; } = null!;

    public virtual City? City { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
