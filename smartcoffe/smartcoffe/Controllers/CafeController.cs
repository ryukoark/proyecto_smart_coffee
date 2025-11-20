using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.Cafes.Dtos;

// ✔ Importamos cada command desde su carpeta correcta
using smartcoffe.Application.Features.Cafes.Commands.CreateCafe;
using smartcoffe.Application.Features.Cafes.Commands.UpdateCafe;
using smartcoffe.Application.Features.Cafes.Commands.DeleteCafe;

// ✔ Queries correctas
using smartcoffe.Application.Features.Cafes.Queries.GetAllCafesQuery;
using smartcoffe.Application.Features.Cafes.Queries.GetCafeByIdQuery;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CafeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CafeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/cafe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CafeListDto>>> GetAll()
        {
            var cafes = await _mediator.Send(new GetAllCafesQuery());
            return Ok(cafes);
        }

        // GET: api/cafe/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CafeGetDto>> GetById(int id)
        {
            var cafe = await _mediator.Send(new GetCafeByIdQuery(id));

            if (cafe == null)
                return NotFound($"No se encontró un café con ID {id}");

            return Ok(cafe);
        }

        // POST: api/cafe
        [HttpPost]
        public async Task<ActionResult<CafeGetDto>> Create([FromBody] CafeCreateDto dto)
        {
            if (dto == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            var result = await _mediator.Send(new CreateCafeCommand(dto));

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/cafe/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CafeGetDto>> Update(int id, [FromBody] CafeUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");

            dto.Id = id;

            var updatedCafe = await _mediator.Send(new UpdateCafeCommand(dto));

            if (updatedCafe == null)
                return NotFound($"No se pudo actualizar el café con ID {id}");

            return Ok(updatedCafe);
        }

        // DELETE: api/cafe/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteCafeCommand(id));

            if (!success)
                return NotFound($"No se encontró un café con ID {id} para eliminar.");

            return Ok($"Café con ID {id} eliminado correctamente.");
        }
    }
}
