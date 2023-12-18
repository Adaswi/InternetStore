using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class PaymentStatus
{
    public decimal PaymentStatusId { get; set; }

    public string PaymentStatusName { get; set; } = null!;

    public virtual ICollection<PaymentStatusHistory> PaymentStatusHistories { get; set; } = new List<PaymentStatusHistory>();
}
