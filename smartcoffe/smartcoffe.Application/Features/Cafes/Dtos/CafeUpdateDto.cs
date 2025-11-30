namespace smartcoffe.Application.Features.Cafes.Dtos
{
    public class CafeUpdateDto
    {
        public int Id { get; set; } // ✅ agregado para identificar el café a actualizar
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Company { get; set; }
        public string Status { get; set; }
    }
}