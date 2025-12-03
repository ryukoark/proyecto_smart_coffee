namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos
{
    public class CafeUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; } // <- doble d
        public string? Company { get; set; }
        public bool Status { get; set; }
    }
}
