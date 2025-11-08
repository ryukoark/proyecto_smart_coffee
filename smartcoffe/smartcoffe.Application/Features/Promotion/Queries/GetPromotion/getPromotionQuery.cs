using MediatR;
using smartcoffe.Application.Promotion.DTos;

namespace smartcoffe.Application.Promotion.Queries.PromotionGet;

public record getAllPromotionsQuery() : IRequest<IEnumerable<promotionDTo>>;