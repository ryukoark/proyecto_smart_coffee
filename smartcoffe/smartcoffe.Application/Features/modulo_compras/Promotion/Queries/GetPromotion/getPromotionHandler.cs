using MediatR;
using smartcoffe.Application.Features.modulo_compras.Promotion.DTos;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.Promotion.Queries.GetPromotion;

public class GetAllPromotionsHandler : IRequestHandler<GetAllPromotionsQuery, IEnumerable<PromotionDTo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPromotionsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PromotionDTo>> Handle(GetAllPromotionsQuery request, CancellationToken cancellationToken)
    {
        var promotions = await _unitOfWork.Repository<Domain.Entities.Promotion>().GetAllAsync();

        var activePromotions = promotions
            .Where(p => p.Status == true)
            .Select(p => new PromotionDTo
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