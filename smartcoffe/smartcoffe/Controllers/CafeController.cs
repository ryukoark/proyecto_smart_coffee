using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.Cafes.Commands;
using smartcoffe.Application.Features.Cafes.Dtos;
using smartcoffe.Application.Features.Cafes.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CafeController(IMediator mediator) : ControllerBase
    {
        // ✅ GET: api/cafe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CafeListDto>>> GetAll()
        {
            var cafes = await mediator.Send(new GetAllCafes());
            return Ok(cafes);
        }

        // ✅ GET: api/cafe/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CafeGetDto>> GetById(int id)
        {
            var cafe = await mediator.Send(new GetCafeById(id));
            if (cafe == null)
                return NotFound($"No se encontró un café con ID {id}");

            return Ok(cafe);
        }

        // ✅ POST: api/cafe
        [HttpPost]
        public async Task<ActionResult<CafeGetDto>> Create([FromBody] CafeCreateDto dto)
        {
            if (dto == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            var result = await mediator.Send(new CreateCafe(dto));
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // ✅ PUT: api/cafe/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CafeGetDto>> Update(int id, [FromBody] CafeUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            // Puedes validar si el café existe antes de actualizarlo
            var updatedCafe = await mediator.Send(new UpdateCafe(dto));
            if (updatedCafe == null)
                return NotFound($"No se pudo actualizar el café con ID {id}");

            return Ok(updatedCafe);
        }

        // ✅ DELETE: api/cafe/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await mediator.Send(new DeleteCafe(id));
            if (!success)
                return NotFound($"No se encontró un café con ID {id} para eliminar.");

            return Ok($"Café con ID {id} eliminado correctamente.");
        }
    }
}