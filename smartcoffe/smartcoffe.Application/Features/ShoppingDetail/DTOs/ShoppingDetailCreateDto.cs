namespace smartcoffe.Application.DTOs.ShoppingDetail
{
    public class ShoppingDetailCreateDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string BuyerName { get; set; }
        public string PaymentMethod { get; set; }
    }
}