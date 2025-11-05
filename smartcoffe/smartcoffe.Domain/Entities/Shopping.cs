using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class Shopping
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public DateTime Date { get; set; }

    public decimal Total { get; set; }

    public decimal? Discount { get; set; }

    public string? Promotion { get; set; }

    public bool Status { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();

    public virtual ICollection<ShoppingDetail> ShoppingDetails { get; set; } = new List<ShoppingDetail>();
}
