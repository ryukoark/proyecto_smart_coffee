using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Promotion.Commands.CreatePromotion;
using smartcoffe.Application.Promotion.Commands.DeletePromotion;
using smartcoffe.Application.Promotion.Commands.UpdatePromotion;
using smartcoffe.Application.Promotion.DTos;
using smartcoffe.Application.Promotion.Queries.PromotionGet;
using smartcoffe.Application.Promotion.Queries.PromotionGetById;

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
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] promotionCreateDTo dto)
    {
        await _mediator.Send(new createPromotionCommand(dto));
        return Ok(new { message = "Promotion created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] promotionUpdateDTo dto)
    {
        dto.id = id;
        await _mediator.Send(new updatePromotionCommand(id, dto));
        return Ok(new { message = "Promotion updated successfully" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new getAllPromotionsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new getPromotionByIdQuery(id));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        await _mediator.Send(new deletePromotionCommand(id));
        return Ok(new { message = "Promotion disabled (soft deleted)" });
    }
    
}