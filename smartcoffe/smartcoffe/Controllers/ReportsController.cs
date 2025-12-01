using MediatR;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.Reports.InventoryByCafe;
using smartcoffe.Application.Features.Reports.ProductsExpiring;
using smartcoffe.Application.Features.Reports.ReservationsByCafe;
using smartcoffe.Application.Features.Reports.TopProducts;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/reports")]
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
    }
}
