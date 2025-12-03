using MediatR;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}