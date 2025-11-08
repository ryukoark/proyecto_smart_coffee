using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.PurchaseHistory.Commands;
using smartcoffe.Application.PurchaseHistory.Queries;
using smartcoffe.Application.Features.PurchaseHistory.DTOs;

namespace smartcoffe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseHistoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public PurchaseHistoryController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PurchaseHistoryCreateDto dto, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new CreatePurchaseHistoryCommand(dto), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PurchaseHistoryUpdateDto dto, CancellationToken cancellationToken)
    {
        dto.Id = id;
        await _mediator.Send(new UpdatePurchaseHistoryCommand(dto), cancellationToken);
        return NoContent();
    }

    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus([FromRoute] int id, [FromBody] PurchaseHistoryStatusUpdateDto dto, CancellationToken cancellationToken)
    {
        dto.Id = id;
        await _mediator.Send(new UpdatePurchaseHistoryStatusCommand(dto), cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeletePurchaseHistoryCommand(new PurchaseHistoryDeleteDto { Id = id }), cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPurchaseHistoryByListQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPurchaseHistoryByIdQuery { Id = id }, cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }
}
    