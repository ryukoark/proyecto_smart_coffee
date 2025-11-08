namespace smartcoffe.Application.DTOs;

public class PurchaseHistoryGetDto
{
	public int Id { get; set; }
	public int? IdUser { get; set; }
	public int? IdShopping { get; set; }
	public bool Status { get; set; }
}
