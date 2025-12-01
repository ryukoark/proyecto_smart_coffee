using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.Cafes.Commands.CreateCafe;
using smartcoffe.Application.Features.Cafes.Commands.UpdateCafe;
using smartcoffe.Application.Features.Cafes.Commands.DeleteCafe;
using smartcoffe.Application.Features.Cafes.Dtos;
using smartcoffe.Application.Features.Cafes.Queries.GetAllCafesQuery;
using smartcoffe.Application.Features.Cafes.Queries.GetCafesByIdQuery;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CafeListDto>>> GetAll()
        {
            var cafes = await _mediator.Send(new GetAllCafesQuery());
            return Ok(cafes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CafeGetDto>> GetById(int id)
        {
            var cafe = await _mediator.Send(new GetCafeByIdQuery(id));

            if (cafe == null)
                return NotFound($"No se encontró un café con ID {id}");

            return Ok(cafe);
        }

        [HttpPost]
        public async Task<ActionResult<CafeGetDto>> Create([FromBody] CafeCreateDto dto)
        {
            var created = await _mediator.Send(new CreateCafeCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CafeGetDto>> Update(int id, [FromBody] CafeUpdateDto dto)
        {
            dto.Id = id;

            var result = await _mediator.Send(new UpdateCafeCommand(dto));

            if (result == null)
                return NotFound($"No se pudo actualizar el café con ID {id}");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteCafeCommand(id));

            if (!deleted)
                return NotFound($"No se encontró el café con ID {id}");

            return Ok($"Café con ID {id} eliminado correctamente.");
        }
    }
}
