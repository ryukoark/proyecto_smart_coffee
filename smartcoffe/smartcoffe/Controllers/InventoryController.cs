using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Queries;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.CreateInventory;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.DeleteInventory;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.UpdateInventory;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Queries.GetAllInventoriesQuery;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Queries.GetInventoryByIdQuery;


namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/inventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryListDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllInventoriesQuery());
            return Ok(result);
        }

        // GET: api/inventory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryGetDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetInventoryByIdQuery(id));
            return result == null ? NotFound($"No se encontró inventario con ID {id}") : Ok(result);
        }

        // POST - Solo Administrador
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<InventoryGetDto>> Create([FromBody] InventoryCreateDto dto)
        {
            if (dto == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            var result = await _mediator.Send(new CreateInventoryCommand(dto));

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT - Solo Administrador
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<InventoryGetDto>> Update(int id, [FromBody] InventoryUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            dto.Id = id;

            var result = await _mediator.Send(new UpdateInventoryCommand(dto));

            return result == null
                ? NotFound($"No se pudo actualizar el inventario con ID {id}")
                : Ok(result);
        }

        // DELETE - Solo Administrador
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteInventoryCommand(id));

            return !success
                ? NotFound($"Inventario con ID {id} no encontrado.")
                : Ok($"Inventario {id} eliminado correctamente.");
        }
    }
}
