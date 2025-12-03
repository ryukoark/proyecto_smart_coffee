namespace smartcoffe.Application.Features.Product.DTOs
{
    // Este DTO se usará para respuestas detalladas (ej. GetById)
    public class ProductDto
    {
        public int Id { get; set; }
        public string Productname { get; set; } = null!;
        public DateOnly? Expirationdate { get; set; }
        public decimal Price { get; set; }
        public int? IdCategory { get; set; }
        public int? IdPromotion { get; set; }
        public bool Status { get; set; }
        
        public string? Img { get; set; }
        // Opcional: Podríamos incluir nombres de categoría/promoción si los cargamos,
        // pero por ahora mantenemoslo simple.
        // public string? CategoryName { get; set; }
        // public string? PromotionName { get; set; }
    }
}