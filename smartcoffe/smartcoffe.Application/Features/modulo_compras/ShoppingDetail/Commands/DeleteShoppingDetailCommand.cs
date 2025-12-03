using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.Commands
{
    public class DeleteShoppingDetailCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteShoppingDetailCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteShoppingDetailCommandHandler : IRequestHandler<DeleteShoppingDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteShoppingDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteShoppingDetailCommand request, CancellationToken cancellationToken)
        {
            var shoppingDetail = await _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().GetByIdAsync(request.Id);
            if (shoppingDetail == null) return false;

            _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().Remove(shoppingDetail);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}