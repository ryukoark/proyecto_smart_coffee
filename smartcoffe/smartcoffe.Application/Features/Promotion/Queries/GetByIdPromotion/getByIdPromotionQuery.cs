using MediatR;
using smartcoffe.Application.Promotion.DTos;

namespace smartcoffe.Application.Promotion.Queries.PromotionGetById;

public record getPromotionByIdQuery(int Id) : IRequest<promotionDTo>;