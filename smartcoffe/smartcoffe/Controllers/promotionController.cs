using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.modulo_compras.Promotion.Commands.CreatePromotion;
using smartcoffe.Application.Features.modulo_compras.Promotion.Commands.DeletePromotion;
using smartcoffe.Application.Features.modulo_compras.Promotion.Commands.UpdatePromotion;
using smartcoffe.Application.Features.modulo_compras.Promotion.DTos;
using smartcoffe.Application.Features.modulo_compras.Promotion.Queries.GetByIdPromotion;
using smartcoffe.Application.Features.modulo_compras.Promotion.Queries.GetPromotion;

namespace smartcoffe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PromotionController : ControllerBase
{
    private readonly IMediator _mediator;

    public PromotionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // POST - Solo Administrador
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Create([FromBody] PromotionCreateDTo dto)
    {
        await _mediator.Send(new CreatePromotionCommand(dto));
        return Ok(new { message = "Promotion created successfully" });
    }

    // PUT - Solo Administrador
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Update(int id, [FromBody] promotionUpdateDTo dto)
    {
        dto.id = id;
        await _mediator.Send(new UpdatePromotionCommand(id, dto));
        return Ok(new { message = "Promotion updated successfully" });
    }
    // GET All - Accesible por Cliente y Administrador
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPromotionsQuery());
        return Ok(result);
    }
    // GET By Id - Accesible por Cliente y Administrador
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetPromotionByIdQuery(id));
        return Ok(result);
    }

    // DELETE (SoftDelete) - Solo Administrador
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        await _mediator.Send(new DeletePromotionCommand(id));
        return Ok(new { message = "Promotion disabled (soft deleted)" });
    }
    
}