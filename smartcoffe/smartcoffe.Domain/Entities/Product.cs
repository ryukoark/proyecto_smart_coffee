using System;
using System.Collections.Generic;

namespace smartcoffe.Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Productname { get; set; } = null!;

    public DateOnly? Expirationdate { get; set; }

    public decimal Price { get; set; }

    public int? IdCategory { get; set; }

    public int? IdPromotion { get; set; }

    public bool Status { get; set; }
    
    public string? Description { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Promotion? IdPromotionNavigation { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    
    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();
    public virtual ICollection<ShoppingDetail> ShoppingDetails { get; set; } = new List<ShoppingDetail>();
}
