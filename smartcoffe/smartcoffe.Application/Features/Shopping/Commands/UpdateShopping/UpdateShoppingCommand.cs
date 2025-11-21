using MediatR;
using smartcoffe.Application.DTOs.Shopping;

namespace smartcoffe.Application.Features.Shopping.Commands.UpdateShopping
{
    public class UpdateShoppingCommand : IRequest<bool>
    {
        public ShoppingUpdateDto Shopping { get; set; }

        public UpdateShoppingCommand(int id, ShoppingUpdateDto shopping)
        {
            Shopping = shopping;
        }
    }
}