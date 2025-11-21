using MediatR;
using smartcoffe.Application.DTOs.Shopping;

namespace smartcoffe.Application.Features.Shopping.Queries.GetShoppingById
{
    public class GetShoppingByIdQuery : IRequest<ShoppingDto>
    {
        public int Id { get; set; }

        public GetShoppingByIdQuery(int id)
        {
            Id = id;
        }
    }
}