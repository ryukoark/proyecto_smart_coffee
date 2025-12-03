namespace smartcoffe.Application.Features.modulo_compras.Shopping.DTOs
{
    public class ShoppingGetDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}