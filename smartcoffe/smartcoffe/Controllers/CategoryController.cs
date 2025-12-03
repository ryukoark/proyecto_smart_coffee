using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.Commands.CreateCategory;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.Commands.DeleteCategory;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.Commands.UpdateCategory;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.DTOs;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.Queries.GetAllCategoriesQuery;
using smartcoffe.Application.Features.modulo_productos_inventarios.Category.Queries.GetCategoryByIdQuery;

namespace smartcoffe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var category = await _mediator.Send(query);

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            // Mapeo manual de DTO a Command
            // Podrías usar AutoMapper aquí para simplificar
            var command = new CreateCategoryCommand
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
                Status = createCategoryDto.Status
            };

            var categoryId = await _mediator.Send(command);

            // Retorna 201 Created con la ubicación del nuevo recurso
            return CreatedAtAction(nameof(GetById), new { id = categoryId }, categoryId);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (id != updateCategoryDto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo de la solicitud.");
            }

            var command = new UpdateCategoryCommand
            {
                Id = id,
                Name = updateCategoryDto.Name,
                Description = updateCategoryDto.Description,
                Status = updateCategoryDto.Status
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound($"No se encontró la categoría con ID {id} para actualizar.");
            }

            return NoContent(); // 204 No Content es estándar para actualizaciones exitosas
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound($"No se encontró la categoría con ID {id} para eliminar.");
            }

            return NoContent();
        }
    }
}