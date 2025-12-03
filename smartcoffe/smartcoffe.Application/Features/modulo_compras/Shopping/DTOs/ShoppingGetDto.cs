namespace smartcoffe.Application.Features.modulo_compras.Shopping.DTOs
{
    public class ShoppingGetDto
    {
        public int Id { get; set; }
        public int? IdProduct { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        // Importe total calculado: Price * Quantity
        public decimal Amount { get; set; }
        // Fecha/hora en formato ISO — usar DateTimeOffset para zonas horarias
        public DateTimeOffset PurchaseDate { get; set; }
        public string BuyerName { get; set; }
        public string PaymentMethod { get; set; }
        public int? IdShopping { get; set; }
    }
}