using Microsoft.AspNetCore.Mvc;
using MediatR;
using smartcoffe.Application.Features.Payments.Commands.CreatePayment;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("init")]
        public async Task<IActionResult> InitializePayment([FromBody] CreatePaymentCommand command)
        {
            try
            {
                var formToken = await _mediator.Send(command);
                return Ok(new { formToken });
            }
            catch (Exception ex)
            {
                // En producción no devuelvas ex.Message directamente por seguridad
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}