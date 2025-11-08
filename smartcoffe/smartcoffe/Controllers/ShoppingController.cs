using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.DTOs.Shopping;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<ShoppingGetDto> GetShopping(int id)
        {
            // Lógica para obtener un shopping
            return Ok(new ShoppingGetDto
            {
                Id = id,
                ProductName = "Coffee",
                Price = 5.99m,
                PurchaseDate = DateTime.Now
            });
        }

        [HttpPost]
        public IActionResult CreateShopping([FromBody] ShoppingCreateDto dto)
        {
            // Lógica para crear un shopping
            return CreatedAtAction(nameof(GetShopping), new { id = 1 }, dto);
        }
    }
}