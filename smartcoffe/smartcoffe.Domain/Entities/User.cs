using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rrole { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();

    public virtual ICollection<Shopping> Shoppings { get; set; } = new List<Shopping>();
}
