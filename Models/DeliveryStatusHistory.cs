using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class DeliveryStatusHistory
{
    public decimal DeliveryStatusHistoryId { get; set; }

    public decimal DeliveryStatusId { get; set; }

    public decimal OrderId { get; set; }

    public DateTime DeliveryStatusHistoryDate { get; set; }

    public virtual DeliveryStatus DeliveryStatus { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
