using MediatR;

namespace smartcoffe.Application.Features.Promotion.Commands.DeletePromotion;

public record DeletePromotionCommand(int Id) : IRequest;
