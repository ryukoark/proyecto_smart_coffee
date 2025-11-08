using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.DTOs;
using smartcoffe.Application.DTOs.ShoppingDetail;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : ControllerBase
    {
        [HttpGet("details/{id}")]
        public ActionResult<ShoppingDetailGetDto> GetShoppingDetail(int id)
        {
            // Lógica para obtener un shopping detallado
            return Ok(new ShoppingDetailGetDto
            {
                Id = id,
                ProductName = "Coffee",
                Price = 5.99m,
                PurchaseDate = DateTime.Now,
                BuyerName = "John Doe",
                PaymentMethod = "Credit Card"
            });
        }

        [HttpPost("details")]
        public IActionResult CreateShoppingDetail([FromBody] ShoppingDetailCreateDto dto)
        {
            // Lógica para crear un shopping detallado
            return CreatedAtAction(nameof(GetShoppingDetail), new { id = 1 }, dto);
        }
    }
}