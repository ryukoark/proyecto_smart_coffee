using MediatR;
using smartcoffe.Application.Features.modulo_compras.Promotion.DTos;

namespace smartcoffe.Application.Features.modulo_compras.Promotion.Queries.GetPromotion;

public record GetAllPromotionsQuery() : IRequest<IEnumerable<PromotionDTo>>;