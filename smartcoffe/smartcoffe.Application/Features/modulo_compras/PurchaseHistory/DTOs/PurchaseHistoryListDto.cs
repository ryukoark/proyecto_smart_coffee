namespace smartcoffe.Application.Features.modulo_compras.PurchaseHistory.DTOs;

public class PurchaseHistoryListDto
{
    public int Id { get; set; }
    public int? IdUser { get; set; }
    public int? IdShopping { get; set; }
    public string? IdPayment { get; set; }
    public bool Status { get; set; }
}
