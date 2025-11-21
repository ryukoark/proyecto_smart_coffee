using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.ShoppingDetail.Queries
{
    public class GetShoppingDetailByIdQuery : IRequest<ShoppingDetailGetDto>
    {
        public int Id { get; set; }

        public GetShoppingDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}