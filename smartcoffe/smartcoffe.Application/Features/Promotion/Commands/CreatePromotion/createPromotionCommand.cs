using MediatR;
using smartcoffe.Application.Promotion.DTos;

namespace smartcoffe.Application.Promotion.Commands.CreatePromotion;

public record createPromotionCommand(promotionCreateDTo Promotion) : IRequest;