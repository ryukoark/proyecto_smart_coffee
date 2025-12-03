using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.DTOs;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Category.Queries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}