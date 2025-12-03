namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs
{
    public class ShoppingDetailGetDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BuyerName { get; set; }
        public string PaymentMethod { get; set; }
    }
}