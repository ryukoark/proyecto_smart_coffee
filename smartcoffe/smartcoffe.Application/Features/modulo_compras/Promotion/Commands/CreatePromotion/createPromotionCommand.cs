using MediatR;
using smartcoffe.Application.Features.modulo_compras.Promotion.DTos;

namespace smartcoffe.Application.Features.modulo_compras.Promotion.Commands.CreatePromotion;

public record CreatePromotionCommand(PromotionCreateDTo Promotion) : IRequest;