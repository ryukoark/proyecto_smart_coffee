using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.modulo_compras.Shopping.Commands;
using smartcoffe.Application.Features.modulo_compras.Shopping.DTOs;
using smartcoffe.Application.Features.modulo_compras.Shopping.Queries;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/shopping/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingGetDto>> GetShoppingById(int id)
        {
            var query = new GetShoppingByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/shopping
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingListDto>>> GetAllShoppings()
        {
            var query = new GetAllShoppingsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // POST: api/shopping
        [HttpPost]
        public async Task<ActionResult<int>> CreateShopping([FromBody] ShoppingCreateDto dto)
        {
            var command = new CreateShoppingCommand(dto);
            var shoppingId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetShoppingById), new { id = shoppingId }, shoppingId);
        }

        // PUT: api/shopping/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShopping(int id, [FromBody] ShoppingUpdateDto dto)
        {
            var command = new UpdateShoppingCommand(id, dto);
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/shopping/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopping(int id)
        {
            var command = new DeleteShoppingCommand(id); // Necesitas implementar este command
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}