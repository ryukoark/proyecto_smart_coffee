using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.DTOs.ShoppingDetail;
using smartcoffe.Application.Features.ShoppingDetail.Commands;
using smartcoffe.Application.Features.ShoppingDetail.Queries;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/shoppingdetail/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingDetailGetDto>> GetShoppingDetailById(int id)
        {
            var query = new GetShoppingDetailByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/shoppingdetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingDetailGetDto>>> GetAllShoppingDetails()
        {
            var query = new GetAllShoppingDetailsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // POST: api/shoppingdetail
        [HttpPost]
        public async Task<ActionResult<int>> CreateShoppingDetail([FromBody] ShoppingDetailCreateDto dto)
        {
            var command = new CreateShoppingDetailCommand(dto);
            var shoppingDetailId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetShoppingDetailById), new { id = shoppingDetailId }, shoppingDetailId);
        }

        // PUT: api/shoppingdetail/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoppingDetail(int id, [FromBody] ShoppingDetailCreateDto dto)
        {
            var command = new UpdateShoppingDetailCommand(id, dto);
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/shoppingdetail/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingDetail(int id)
        {
            var command = new DeleteShoppingDetailCommand(id); // Necesitas implementar este command
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}