using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.Inventory.Commands;
using smartcoffe.Application.Features.Inventory.DTOs;
using smartcoffe.Application.Features.Inventory.Queries.GetAllInventoriesQuery;
using smartcoffe.Application.Features.Inventory.Queries.GetInventoryByIdQuery;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/inventory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllInventoriesQuery());
            return Ok(result);
        }

        // GET: api/inventory/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetInventoryByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }

        // POST: api/inventory
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryCreateDto dto)
        {
            var result = await _mediator.Send(new CreateInventory(dto));
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/inventory
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InventoryUpdateDto dto)
        {
            var result = await _mediator.Send(new UpdateInventory(dto));
            return result == null ? NotFound() : Ok(result);
        }

        // DELETE: api/inventory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteInventory(id));
            return !success ? NotFound() : Ok($"Inventario {id} eliminado.");
        }
    }
}
