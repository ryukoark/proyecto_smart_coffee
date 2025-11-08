using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Promotion.Commands.UpdatePromotion;

public class updatePromotionHandler : IRequestHandler<updatePromotionCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public updatePromotionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(updatePromotionCommand request, CancellationToken cancellationToken)
    {
        var existingPromotion = await _unitOfWork.Promotions.GetByIdAsync(request.Id);
        if (existingPromotion == null)
        {
            throw new KeyNotFoundException($"Promotion with ID {request.Id} not found.");
        }

        var dto = request.Promotion;
        
        existingPromotion.Name = dto.name;
        existingPromotion.Amount = dto.amount;
        existingPromotion.Type = dto.type;
        existingPromotion.Startdate = dto.startDate;
        existingPromotion.Enddate = dto.endDate;
        existingPromotion.Status = dto.Status;

        _unitOfWork.Promotions.Update(existingPromotion);
        await _unitOfWork.CompleteAsync();
    }
}