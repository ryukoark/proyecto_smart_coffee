using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class ShoppingDetail
{
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal Amount { get; set; }

    public int? IdShopping { get; set; }

    public bool Status { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Shopping? IdShoppingNavigation { get; set; }
}
