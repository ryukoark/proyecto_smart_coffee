namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos
{
    public class CafeDeleteDto
    {
        public int Id { get; set; }
        public string? Reason { get; set; }
        public string? DeletedBy { get; set; }
        public string? Status { get; set; } = "Inactive";
    }
}