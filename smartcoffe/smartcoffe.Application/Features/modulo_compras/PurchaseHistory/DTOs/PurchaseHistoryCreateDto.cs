namespace smartcoffe.Application.Features.modulo_compras.PurchaseHistory.DTOs;

public class PurchaseHistoryCreateDto
{
    public int IdUser { get; set; }
    public int IdShopping { get; set; }
    public string? IdPayment { get; set; }
    public bool? Status { get; set; }
}
