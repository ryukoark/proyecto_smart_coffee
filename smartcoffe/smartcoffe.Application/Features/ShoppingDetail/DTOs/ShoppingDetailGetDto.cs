namespace smartcoffe.Application.DTOs.ShoppingDetail
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