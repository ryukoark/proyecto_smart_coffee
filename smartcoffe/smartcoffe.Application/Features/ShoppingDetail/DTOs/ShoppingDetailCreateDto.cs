namespace smartcoffe.Application.DTOs.ShoppingDetail;

public class ShoppingDetailCreateDto
{
    public int Id { get; set; }
    public int IdProduct { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int IdShopping { get; set; }
    public bool Status { get; set; }
}