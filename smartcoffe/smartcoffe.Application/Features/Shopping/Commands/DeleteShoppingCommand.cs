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

    public class DeleteShoppingCommandHandler : IRequestHandler<DeleteShoppingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteShoppingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteShoppingCommand request, CancellationToken cancellationToken)
        {
            var shopping = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (shopping == null) return false;

            _unitOfWork.Products.Remove(shopping);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}