namespace smartcoffe.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        // Opcional: Si quieres incluir la cantidad de productos en la categoría
        // public int ProductCount { get; set; } 
    }
}