using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class Inventory
{
    public int Id { get; set; }

    public int? IdCafe { get; set; }

    public int? IdProduct { get; set; }

    public int Quantity { get; set; }

    public int? IdSupplier { get; set; }

    public bool Status { get; set; }

    public virtual Cafe? IdCafeNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Supplier? IdSupplierNavigation { get; set; }
}
