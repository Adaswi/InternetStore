using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class PaymentMethod
{
    public decimal PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
