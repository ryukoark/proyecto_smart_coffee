namespace smartcoffe.Application.Features.Supplier.DTOs
{
    public class SupplierCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool Status { get; set; } = true; // Valor por defecto al crear
    }
}