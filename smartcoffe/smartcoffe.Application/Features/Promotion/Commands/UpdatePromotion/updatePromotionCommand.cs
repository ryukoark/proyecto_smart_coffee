using MediatR;
using smartcoffe.Application.Promotion.DTos;

namespace smartcoffe.Application.Promotion.Commands.UpdatePromotion;

public record updatePromotionCommand(int Id, promotionUpdateDTo Promotion) : IRequest;
