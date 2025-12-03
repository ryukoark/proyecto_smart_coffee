namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs
{
    // DTO para respuestas detalladas (ej. GetById)
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool Status { get; set; }
    }
}