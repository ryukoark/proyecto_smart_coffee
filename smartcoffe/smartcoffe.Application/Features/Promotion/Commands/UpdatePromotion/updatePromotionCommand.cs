using MediatR;
using smartcoffe.Application.Promotion.DTos;

namespace smartcoffe.Application.Features.Promotion.Commands.UpdatePromotion;

public record UpdatePromotionCommand(int Id, promotionUpdateDTo Promotion) : IRequest;
