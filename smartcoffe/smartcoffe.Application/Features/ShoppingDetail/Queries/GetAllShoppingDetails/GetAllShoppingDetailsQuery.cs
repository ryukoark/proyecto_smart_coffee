using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;

namespace smartcoffe.Application.Features.ShoppingDetail.Queries.GetAllShoppingDetails
{
    public class GetAllShoppingDetailsQuery : IRequest<IEnumerable<ShoppingDetailGetDto>>
    {
    }
}