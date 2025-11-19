using MediatR;
using smartcoffe.Application.Features.Promotion.Commands.UpdatePromotion;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Promotion.Commands.UpdatePromotion;

public class updatePromotionHandler : IRequestHandler<UpdatePromotionCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public updatePromotionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
    {
        var existingPromotion = await _unitOfWork.Repository<Domain.Entities.Promotion>().GetByIdAsync(request.Id);
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

        _unitOfWork.Repository<Domain.Entities.Promotion>().Update(existingPromotion);
        await _unitOfWork.CompleteAsync();
    }
}