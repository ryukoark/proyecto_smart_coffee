using MediatR;
using smartcoffe.Application.Promotion.DTos;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Promotion.Queries.PromotionGet;

public class getAllPromotionsHandler : IRequestHandler<getAllPromotionsQuery, IEnumerable<promotionDTo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public getAllPromotionsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<promotionDTo>> Handle(getAllPromotionsQuery request, CancellationToken cancellationToken)
    {
        var promotions = await _unitOfWork.Promotions.GetAllAsync();

        var activePromotions = promotions
            .Where(p => p.Status == true)
            .Select(p => new promotionDTo
            {
                name = p.Name,
                amount = p.Amount ?? 0,
                type = p.Type ?? string.Empty,
                startDate = p.Startdate ?? default,
                endDate = p.Enddate ?? default,
            })
            .ToList();

        return activePromotions;
    }
}