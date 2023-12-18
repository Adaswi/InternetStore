using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class PaymentStatusHistory
{
    public decimal PaymentStatusHistoryId { get; set; }

    public decimal PaymentStatusId { get; set; }

    public decimal PaymentId { get; set; }

    public DateTime PaymentStatusHistoryDate { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual PaymentStatus PaymentStatus { get; set; } = null!;
}
