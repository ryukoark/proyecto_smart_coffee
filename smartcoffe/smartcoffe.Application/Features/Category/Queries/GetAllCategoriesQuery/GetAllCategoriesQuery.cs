using MediatR;
using smartcoffe.Application.DTOs;

namespace smartcoffe.Application.Features.Category.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}