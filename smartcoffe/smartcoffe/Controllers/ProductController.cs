using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.Commands.CreateProduct;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.Commands.DeleteProduct;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.Commands.UpdateProduct;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.DTOs;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.Queries.GetAllProducts;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.Queries.GetProductById;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Accesible por ambos roles de consumidor
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/product - Solo Administrador
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            // Envía el comando al handler de CreateProduct
            await _mediator.Send(new CreateProductCommand(dto));
            return Ok(new { message = "Producto creado exitosamente" });
        }

        // PUT api/product/5 - Solo Administrador
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            // --- AÑADIR ESTA LÍNEA ---
            dto.Id = id; 
            // -------------------------
            // Envía el comando al handler de UpdateProduct
            // El DTO de update no necesita el id, se pasa por separado.
            await _mediator.Send(new UpdateProductCommand(id, dto));
            return Ok(new { message = "Producto actualizado exitosamente" });
        }

        // GET api/product - Accesible por Cliente y Administrador
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Envía el query al handler de GetAllProducts
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        // GET api/product/5 - Accesible por Cliente y Administrador
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Envía el query al handler de GetProductById
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }

        // DELETE api/product/5 - Solo Administrador
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            // Envía el comando al handler de DeleteProduct (soft delete)
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok(new { message = "Producto deshabilitado (soft delete)" });
        }
    }
}