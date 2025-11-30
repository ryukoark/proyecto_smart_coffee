using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class Reservation
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdCafe { get; set; }

    public DateOnly ReservationDate { get; set; }

    public string ReservationCode { get; set; } = null!;

    public string ReservationStatus { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual Cafe IdCafeNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();
}
