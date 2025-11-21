using MediatR;
using smartcoffe.Application.DTOs.Shopping;

namespace smartcoffe.Application.Features.Shopping.Queries.GetAllShoppings
{
    public class GetAllShoppingsQuery : IRequest<List<ShoppingDto>>
    {
    }
}