using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.modulo_compras.PurchaseHistory.Commands;
using smartcoffe.Application.Features.modulo_compras.PurchaseHistory.DTOs;
using smartcoffe.Application.Features.modulo_compras.PurchaseHistory.Queries;

namespace smartcoffe.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class PurchaseHistoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public PurchaseHistoryController(IMediator mediator) => _mediator = mediator;

    // POST - Solo Administrador (o un proceso interno, pero asumimos Admin para CRUD)
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Create([FromBody] PurchaseHistoryCreateDto dto, CancellationToken cancellationToken)
    {
        // Envía el comando al handler de CreatePurchaseHistory
        await _mediator.Send(new CreatePurchaseHistoryCommand(dto), cancellationToken);
        return Ok(new { message = "PurchaseHistory creado exitosamente" });
    }

    // PUT - Solo Administrador
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PurchaseHistoryUpdateDto dto, CancellationToken cancellationToken)
    {
        // Use route id as the resource identifier; DTO does not carry Id or Status.
        await _mediator.Send(new UpdatePurchaseHistoryCommand(id, dto), cancellationToken);
        return Ok(new { message = "PurchaseHistory actualizado exitosamente" });
    }

    // DELETE - Solo Administrador
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        // Envía el comando al handler de DeletePurchaseHistory (soft/hard según implementación)
        await _mediator.Send(new DeletePurchaseHistoryCommand(new PurchaseHistoryDeleteDto { Id = id }), cancellationToken);
        return Ok(new { message = "PurchaseHistory eliminado/deshabilitado exitosamente" });
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
        // Envía el query al handler de GetPurchaseHistoryById
        var result = await _mediator.Send(new GetPurchaseHistoryByIdQuery { Id = id }, cancellationToken);
        return Ok(result);
    }
}
    