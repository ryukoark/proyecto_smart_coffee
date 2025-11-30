using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class Cafe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Company { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

}
