namespace smartcoffe.Application.Features.Supplier.DTOs
{
    // DTO para listas (ej. GetAll)
    public class SupplierListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool Status { get; set; }
    }
}