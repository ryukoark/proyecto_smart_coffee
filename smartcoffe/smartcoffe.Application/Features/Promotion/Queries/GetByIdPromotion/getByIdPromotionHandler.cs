using MediatR;
using smartcoffe.Application.Features.Promotion.DTos;
using smartcoffe.Application.Promotion.DTos;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Promotion.Queries.GetByIdPromotion;

public class GetPromotionByIdHandler : IRequestHandler<GetPromotionByIdQuery, PromotionDTo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPromotionByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PromotionDTo> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
    {
        var promotion = await _unitOfWork.Repository<Domain.Entities.Promotion>().GetByIdAsync(request.Id);

        if (promotion == null || !promotion.Status)
        {
            throw new KeyNotFoundException($"Promotion with ID {request.Id} not found or inactive.");
        }
        
        var dto = new PromotionDTo
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