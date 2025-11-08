namespace smartcoffe.Application.DTOs;

public class PurchaseHistoryCreateDto
{
	public int IdUser { get; set; }
	public int IdShopping { get; set; }
	public string? IdPayment { get; set; }
	public bool? Status { get; set; }
}