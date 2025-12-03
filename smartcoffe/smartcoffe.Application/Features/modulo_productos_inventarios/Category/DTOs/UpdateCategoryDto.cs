using System.ComponentModel.DataAnnotations;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Category.DTOs
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; } // Necesario para identificar qué categoría actualizar

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Description { get; set; }

        public bool Status { get; set; }
    }
}