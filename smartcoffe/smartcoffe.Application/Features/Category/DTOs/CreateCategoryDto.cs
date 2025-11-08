using System.ComponentModel.DataAnnotations;

namespace smartcoffe.Application.Features.Category.DTOs
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Description { get; set; }

        public bool Status { get; set; } = true; // Por defecto activa al crear
    }
}