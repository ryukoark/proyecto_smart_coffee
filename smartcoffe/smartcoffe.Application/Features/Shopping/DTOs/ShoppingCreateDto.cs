namespace smartcoffe.Application.DTOs.Shopping
{
    public class ShoppingCreateDto
    {
        // Id del producto (si lo tienes) — preferible para relacionar con inventario
        public int? IdProduct { get; set; }

        // Nombre para mostrar (opcional si tienes IdProduct)
        public string ProductName { get; set; }

        // Precio unitario
        public decimal Price { get; set; }

        // Cantidad solicitada
        public int Quantity { get; set; } = 1;

        // Opcional: identifica la orden/cart al que pertenece este detalle
        public int? IdShopping { get; set; }

        // Datos del comprador (opcional)
        public string BuyerName { get; set; }

        // Método de pago preliminar (CARD, CASH, etc.)
        public string PaymentMethod { get; set; }
    }
}