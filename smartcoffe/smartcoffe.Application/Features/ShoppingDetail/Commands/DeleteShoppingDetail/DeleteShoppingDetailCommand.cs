using MediatR;

namespace smartcoffe.Application.Features.ShoppingDetail.Commands.DeleteShoppingDetail
{
    public class DeleteShoppingDetailCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteShoppingDetailCommand(int id)
        {
            Id = id;
        }
    }
}