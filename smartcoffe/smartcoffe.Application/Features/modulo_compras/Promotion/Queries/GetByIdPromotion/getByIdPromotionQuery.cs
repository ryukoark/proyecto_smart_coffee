using MediatR;
using smartcoffe.Application.Features.modulo_compras.Promotion.DTos;

namespace smartcoffe.Application.Features.modulo_compras.Promotion.Queries.GetByIdPromotion;

public record GetPromotionByIdQuery(int Id) : IRequest<PromotionDTo>;