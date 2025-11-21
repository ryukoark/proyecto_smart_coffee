using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;

namespace smartcoffe.Application.Features.ShoppingDetail.Commands.UpdateShoppingDetail
{
    public class UpdateShoppingDetailCommand : IRequest<bool>
    {
        public ShoppingDetailCreateDto ShoppingDetail { get; set; }

        public UpdateShoppingDetailCommand(ShoppingDetailCreateDto shoppingDetail)
        {
            ShoppingDetail = shoppingDetail;
        }
    }
}