using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Commands
{
    public class DeleteShoppingCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteShoppingCommand(int id)
        {
            Id = id;
        }
    }
}