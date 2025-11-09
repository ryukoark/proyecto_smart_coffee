using MediatR;

namespace smartcoffe.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}