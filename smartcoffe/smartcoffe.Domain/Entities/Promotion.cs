using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class Promotion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Amount { get; set; }

    public string? Type { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
