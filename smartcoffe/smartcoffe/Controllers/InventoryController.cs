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

        // ✅ GET: api/inventory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllInventories());
            if (result == null || !result.Any())
                return NotFound("No se encontraron registros de inventario.");

            return Ok(result);
        }

        // ✅ GET: api/inventory/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetInventoryById(id));
            if (result == null)
                return NotFound($"No se encontró el inventario con ID {id}.");

            return Ok(result);
        }

        // ✅ POST: api/inventory
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryCreateDto dto)
        {
            if (dto == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            var result = await _mediator.Send(new CreateInventory(dto));
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // ✅ PUT: api/inventory
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InventoryUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            var result = await _mediator.Send(new UpdateInventory(dto));
            if (result == null)
                return NotFound($"No se pudo actualizar el inventario con ID {dto.Id}.");

            return Ok(result);
        }

        // ✅ DELETE: api/inventory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteInventory(id));
            if (!success)
                return NotFound($"No se encontró el inventario con ID {id}.");

            return Ok($"Inventario con ID {id} eliminado correctamente.");
        }
    }
}