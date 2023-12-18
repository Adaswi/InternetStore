using System;
using System.Collections.Generic;

namespace InternetStore.Models;

public partial class User
{
    public decimal UserId { get; set; }

    public string UserNickname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string? UserNumber { get; set; }

    public string UserPassword { get; set; } = null!;

    public DateTime UserCreationDate { get; set; }

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
