using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class ReservationDetail
{
    public int Id { get; set; }

    public int IdReservation { get; set; }

    public int? IdProduct { get; set; }

    public int? Quantity { get; set; }

    public string? DetailDescription { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Reservation IdReservationNavigation { get; set; } = null!;
}
