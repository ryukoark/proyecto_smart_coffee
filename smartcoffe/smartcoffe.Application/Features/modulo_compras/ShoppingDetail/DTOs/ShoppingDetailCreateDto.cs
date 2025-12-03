namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs
{
    public class ShoppingDetailCreateDto
    {
        public int? IdProduct { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }  // precio unitario
        public int? IdShopping { get; set; } // opcional: vincular a una orden
        public string? BuyerName { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
