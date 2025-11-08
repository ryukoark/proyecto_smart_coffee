using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Promotion.Commands.DeletePromotion;

public class deletePromotionHandler : IRequestHandler<deletePromotionCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public deletePromotionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(deletePromotionCommand request, CancellationToken cancellationToken)
    {
        var promotion = await _unitOfWork.Promotions.GetByIdAsync(request.Id);

        if (promotion == null)
        {
            throw new KeyNotFoundException($"Promotion with ID {request.Id} not found.");
        }
        promotion.Status = false;

        _unitOfWork.Promotions.Update(promotion);
        await _unitOfWork.CompleteAsync();
    }
}