using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Promotion.Commands.CreatePromotion;

public class createPromotionHandler : IRequestHandler<createPromotionCommand>
{
    
    private readonly IUnitOfWork _unitOfWork;

    public createPromotionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(createPromotionCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Promotion;
        var random = new Random();
        var promotion = new Domain.Entities.Promotion
        {
            Id = random.Next(1000, 9999),
            Name = dto.Name,
            Amount = dto.Amount,
            Type = dto.type,
            Startdate = dto.startDate,
            Enddate = dto.endDate,
            Status = dto.Status
        };
        
        await _unitOfWork.Promotions.AddAsync(promotion);
        await _unitOfWork.CompleteAsync();

        return;
    }
}