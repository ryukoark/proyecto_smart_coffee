namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs
{
    public class SupplierUpdateDto
    {
        public int Id { get; set; } // Requerido para saber cuál actualizar
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool Status { get; set; }
    }
}