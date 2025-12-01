using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, string>
    {
        private readonly IPaymentGatewayService _paymentService;

        public CreatePaymentCommandHandler(IPaymentGatewayService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<string> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            // Aquí puedes validar stock, guardar la orden en estado "Pendiente", etc.
            
            // Generar el token de Izipay
            return await _paymentService.GeneratePaymentTokenAsync(
                request.Amount,
                "PEN", // Moneda fija o dinámica
                request.OrderId,
                request.Email,
                request.UserId
            );
        }
    }
}