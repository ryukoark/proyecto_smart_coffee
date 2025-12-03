namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs
{
    public class ShoppingDetailGetDto
    {
        public int Id { get; set; }

        // FK y relación
        public int? IdProduct { get; set; }
        public int? IdShopping { get; set; }

        // Datos para mostrar
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Cantidad y cálculo
        public int Quantity { get; set; }

        // Fecha de compra / creación
        public DateTime PurchaseDate { get; set; }

        // Opcionales (pueden ser nulos si no se persisten aún)
        public string? BuyerName { get; set; }
        public string? PaymentMethod { get; set; }
    }
}