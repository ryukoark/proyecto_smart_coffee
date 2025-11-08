using MediatR;

namespace smartcoffe.Application.Features.Category.Commands.UpdateCategory
{
    // Retorna bool para indicar si se pudo actualizar o no (por ejemplo, si no existe el ID)
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}