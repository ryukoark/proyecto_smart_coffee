using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.DTOs;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Category.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}