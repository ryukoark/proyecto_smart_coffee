using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;

namespace smartcoffe.Application.Features.ShoppingDetail.Commands.CreateShoppingDetail
{
    public class CreateShoppingDetailCommand : IRequest<int>
    {
        public ShoppingDetailCreateDto ShoppingDetail { get; set; }

        public CreateShoppingDetailCommand(ShoppingDetailCreateDto shoppingDetail)
        {
            ShoppingDetail = shoppingDetail;
        }
    }
}