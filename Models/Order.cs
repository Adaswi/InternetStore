using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Order
{
    public decimal OrderId { get; set; }

    public decimal UserId { get; set; }

    public decimal? AdressId { get; set; }

    public decimal OrderPrice { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Adress? Adress { get; set; }

    public virtual ICollection<DeliveryStatusHistory> DeliveryStatusHistories { get; set; } = new List<DeliveryStatusHistory>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User User { get; set; } = null!;
}
