using MediatR;
using smartcoffe.Application.DTOs;

namespace smartcoffe.Application.Features.Category.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}