using MediatR;
using smartcoffe.Application.DTOs.Shopping;

namespace smartcoffe.Application.Features.Shopping.Commands
{
    public class CreateShoppingCommand : IRequest<int>
    {
        public ShoppingCreateDto Shopping { get; set; }

        public CreateShoppingCommand(ShoppingCreateDto shopping)
        {
            Shopping = shopping;
        }
    }
}