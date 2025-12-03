using MediatR;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; } = true;
    }
}