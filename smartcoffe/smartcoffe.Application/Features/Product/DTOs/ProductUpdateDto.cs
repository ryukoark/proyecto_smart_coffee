namespace smartcoffe.Application.Features.Product.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; } // El Id es crucial para saber qué actualizar
        public string Productname { get; set; } = null!;
        public DateOnly? Expirationdate { get; set; }
        public decimal Price { get; set; }
        public int? IdCategory { get; set; }
        public int? IdPromotion { get; set; }
        public bool Status { get; set; }
    }
}