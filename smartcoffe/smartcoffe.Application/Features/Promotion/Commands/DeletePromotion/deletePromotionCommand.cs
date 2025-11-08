using MediatR;

namespace smartcoffe.Application.Promotion.Commands.DeletePromotion;

public record deletePromotionCommand(int Id) : IRequest;
