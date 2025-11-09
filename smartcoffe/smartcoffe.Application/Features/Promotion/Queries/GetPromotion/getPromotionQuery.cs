using MediatR;
using smartcoffe.Application.Features.Promotion.DTos;
using smartcoffe.Application.Promotion.DTos;

namespace smartcoffe.Application.Features.Promotion.Queries.GetPromotion;

public record GetAllPromotionsQuery() : IRequest<IEnumerable<PromotionDTo>>;