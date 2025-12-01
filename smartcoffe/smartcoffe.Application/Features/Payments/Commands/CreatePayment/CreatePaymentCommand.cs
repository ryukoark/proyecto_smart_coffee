using MediatR;

namespace smartcoffe.Application.Features.Payments.Commands.CreatePayment
{
    // Recibe los datos básicos y retorna el string (formToken)
    public record CreatePaymentCommand(decimal Amount, string OrderId, string Email, string UserId) : IRequest<string>;
}