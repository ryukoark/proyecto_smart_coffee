using MediatR;
using smartcoffe.Application.Features.Promotion.DTos;
using smartcoffe.Application.Promotion.DTos;

namespace smartcoffe.Application.Features.Promotion.Commands.CreatePromotion;

public record CreatePromotionCommand(PromotionCreateDTo Promotion) : IRequest;