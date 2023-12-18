using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class Payment
{
    public decimal PaymentId { get; set; }

    public decimal PaymentMethodId { get; set; }

    public decimal OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ICollection<PaymentStatusHistory> PaymentStatusHistories { get; set; } = new List<PaymentStatusHistory>();
}
