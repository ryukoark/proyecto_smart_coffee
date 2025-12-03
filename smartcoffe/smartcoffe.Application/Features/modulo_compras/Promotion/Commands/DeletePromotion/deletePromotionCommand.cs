using MediatR;

namespace smartcoffe.Application.Features.modulo_compras.Promotion.Commands.DeletePromotion;

public record DeletePromotionCommand(int Id) : IRequest;
