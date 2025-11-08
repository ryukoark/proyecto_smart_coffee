using MediatR;
using smartcoffe.Application.Promotion.DTos;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Promotion.Queries.PromotionGetById;

public class getPromotionByIdHandler : IRequestHandler<getPromotionByIdQuery, promotionDTo>
{
    private readonly IUnitOfWork _unitOfWork;

    public getPromotionByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<promotionDTo> Handle(getPromotionByIdQuery request, CancellationToken cancellationToken)
    {
        var promotion = await _unitOfWork.Promotions.GetByIdAsync(request.Id);

        if (promotion == null || !promotion.Status)
        {
            throw new KeyNotFoundException($"Promotion with ID {request.Id} not found or inactive.");
        }
        
        var dto = new promotionDTo
        {
            name = promotion.Name,
            amount = promotion.Amount ?? 0, // por si es null
            type = promotion.Type ?? string.Empty,
            startDate = promotion.Startdate ?? default,
            endDate = promotion.Enddate ?? default,
        };

        return dto;
    }
}