using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.Promotion.Commands.CreatePromotion;
using smartcoffe.Application.Features.Promotion.Commands.DeletePromotion;
using smartcoffe.Application.Features.Promotion.Commands.UpdatePromotion;
using smartcoffe.Application.Features.Promotion.DTos;
using smartcoffe.Application.Features.Promotion.Queries.GetByIdPromotion;
using smartcoffe.Application.Features.Promotion.Queries.GetPromotion;
using smartcoffe.Application.Promotion.DTos;

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
    public async Task<IActionResult> Create([FromBody] PromotionCreateDTo dto)
    {
        await _mediator.Send(new CreatePromotionCommand(dto));
        return Ok(new { message = "Promotion created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] promotionUpdateDTo dto)
    {
        dto.id = id;
        await _mediator.Send(new UpdatePromotionCommand(id, dto));
        return Ok(new { message = "Promotion updated successfully" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPromotionsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetPromotionByIdQuery(id));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        await _mediator.Send(new DeletePromotionCommand(id));
        return Ok(new { message = "Promotion disabled (soft deleted)" });
    }
    
}