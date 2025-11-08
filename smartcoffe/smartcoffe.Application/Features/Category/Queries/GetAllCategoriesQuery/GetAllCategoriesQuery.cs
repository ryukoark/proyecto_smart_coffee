using MediatR;
using smartcoffe.Application.Features.Category.DTOs;

namespace smartcoffe.Application.Features.Category.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}