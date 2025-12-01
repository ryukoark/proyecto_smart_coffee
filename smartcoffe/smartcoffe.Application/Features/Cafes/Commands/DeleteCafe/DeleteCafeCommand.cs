using MediatR;

namespace smartcoffe.Application.Features.Cafes.Commands.DeleteCafe
{
    public class DeleteCafeCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteCafeCommand(int id)
        {
            Id = id;
        }
    }
}