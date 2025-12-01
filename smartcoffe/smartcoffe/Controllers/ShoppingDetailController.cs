using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShoppingDetailController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new Application.Features.ShoppingDetail.Queries.GetShoppingDetailByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ShoppingDetailCreateDto dto)
        {
            var id = await _mediator.Send(new Application.Features.ShoppingDetail.Commands.CreateShoppingDetail.CreateShoppingDetailCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}