using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class PurchaseHistory
{
    public int Id { get; set; }

    public int? Iduser { get; set; }

    public int? Idshopping { get; set; }

    public string? IdPayment { get; set; }

    public bool Status { get; set; }

    public virtual Shopping? IdshoppingNavigation { get; set; }

    public virtual User? IduserNavigation { get; set; }
}
