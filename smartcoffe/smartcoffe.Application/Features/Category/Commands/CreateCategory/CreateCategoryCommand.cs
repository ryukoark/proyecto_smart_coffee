using MediatR;

namespace smartcoffe.Application.Features.Category.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; } = true;
    }
}