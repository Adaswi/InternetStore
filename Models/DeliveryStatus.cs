using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class DeliveryStatus
{
    public decimal DeliveryStatusId { get; set; }

    public string DeliveryStatusName { get; set; } = null!;

    public virtual ICollection<DeliveryStatusHistory> DeliveryStatusHistories { get; set; } = new List<DeliveryStatusHistory>();
}
