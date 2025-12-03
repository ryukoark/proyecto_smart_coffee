using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.Promotion.Commands.DeletePromotion;

public class DeletePromotionHandler : IRequestHandler<DeletePromotionCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePromotionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var promotion = await _unitOfWork.Repository<Domain.Entities.Promotion>().GetByIdAsync(request.Id);

        if (promotion == null)
        {
            throw new KeyNotFoundException($"Promotion with ID {request.Id} not found.");
        }
        promotion.Status = false;

        _unitOfWork.Repository<Domain.Entities.Promotion>().Update(promotion);
        await _unitOfWork.CompleteAsync();
    }
}