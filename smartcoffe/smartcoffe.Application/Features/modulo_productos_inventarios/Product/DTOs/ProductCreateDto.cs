namespace smartcoffe.Application.Features.modulo_productos_inventarios.Product.DTOs
{
    public class ProductCreateDto
    {
        public string Productname { get; set; } = null!;
        public DateOnly? Expirationdate { get; set; }
        public decimal Price { get; set; }
        public int? IdCategory { get; set; }
        public int? IdPromotion { get; set; }
        public bool Status { get; set; } = true; // Valor por defecto al crear
        
        public string? Img { get; set; }
    }
}