namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs
{
    public class ShoppingDetailCreateDto
    {
        public int Id {get; set;}
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string BuyerName { get; set; }
        public string PaymentMethod { get; set; }
    }
}