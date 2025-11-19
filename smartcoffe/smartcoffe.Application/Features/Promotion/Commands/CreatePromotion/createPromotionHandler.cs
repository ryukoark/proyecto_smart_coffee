using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Promotion.Commands.CreatePromotion;

public class CreatePromotionHandler : IRequestHandler<CreatePromotionCommand>
{
    
    private readonly IUnitOfWork _unitOfWork;

    public CreatePromotionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
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
        
        await _unitOfWork.Repository<Domain.Entities.Promotion>().AddAsync(promotion);
        await _unitOfWork.CompleteAsync();

        return;
    }
}