using MediatR;
using smartcoffe.Application.Features.Category.DTOs;

namespace smartcoffe.Application.Features.Category.Queries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}