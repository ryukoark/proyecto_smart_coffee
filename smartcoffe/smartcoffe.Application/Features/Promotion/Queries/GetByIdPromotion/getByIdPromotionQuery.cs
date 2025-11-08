using MediatR;
using smartcoffe.Application.Features.Promotion.DTos;
using smartcoffe.Application.Promotion.DTos;

namespace smartcoffe.Application.Features.Promotion.Queries.GetByIdPromotion;

public record GetPromotionByIdQuery(int Id) : IRequest<PromotionDTo>;