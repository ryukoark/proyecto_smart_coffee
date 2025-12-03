using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.Reports.InventoryByCafe;
using smartcoffe.Application.Features.Reports.ProductsExpiring;
using smartcoffe.Application.Features.Reports.ProductsExpiring.DTOs;
using smartcoffe.Application.Features.Reports.ProductsExpiring.Queries;
using smartcoffe.Application.Features.Reports.ReservationsByCafe;
using smartcoffe.Application.Features.Reports.TopProducts;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/reports")]
    [Authorize(Roles = "Administrador")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("inventory/{cafeId}")]
        public async Task<IActionResult> InventoryByCafe(int cafeId)
        {
            var file = await _mediator.Send(new InventoryByCafeQuery(cafeId));
            return File(file, 
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Inventario.xlsx");
        }

        [HttpGet("products-expiring/{days}")]
        public async Task<IActionResult> ProductsExpiring(int days)
        {
            var file = await _mediator.Send(new ProductsExpiringQuery(days));
            return File(file,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "ProductosExpirar.xlsx");
        }

        [HttpGet("reservations/{cafeId}")]
        public async Task<IActionResult> ReservationsByCafe(int cafeId)
        {
            var file = await _mediator.Send(new ReservationsByCafeQuery(cafeId));
            return File(file,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Reservas.xlsx");
        }

        [HttpGet("top-products")]
        public async Task<IActionResult> TopProducts()
        {
            var file = await _mediator.Send(new TopProductsQuery(int.MaxValue)); // Trae todos
            return File(file,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "TopProductos.xlsx");
        }
        
        [HttpGet("ExpiringProducts")]
        [ProducesResponseType(typeof(List<ExpiringProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductsExpiringSoon([FromQuery] int cafeId)
        {
            if (cafeId <= 0)
            {
                return BadRequest("El ID de la cafetería es requerido.");
            }

            // 1. Crear la Query y asignar el parámetro
            var query = new GetProductsExpiringSoonQuery { 
                CafeId = cafeId 
            };

            // 2. Enviar la Query a través de MediatR para que la procese el Handler
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound($"No se encontraron productos próximos a expirar en la cafetería {cafeId}.");
            }

            return Ok(result);
        }
    }
}
