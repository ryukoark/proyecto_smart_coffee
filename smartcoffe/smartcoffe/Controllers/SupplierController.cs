using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Commands.CreateSupplier;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Commands.DeleteSupplier;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Commands.UpdateSupplier;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Queries.GetAllSuppliers;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Queries.GetSupplierById;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST - Solo Administrador
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([FromBody] SupplierCreateDto dto)
        {
            // Envía el comando al handler de CreateSupplier
            await _mediator.Send(new CreateSupplierCommand(dto));
            return Ok(new { message = "Proveedor creado exitosamente" });
        }

        // PUT - Solo Administrador
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierUpdateDto dto)
        {
            // Envía el comando al handler de UpdateSupplier
            await _mediator.Send(new UpdateSupplierCommand(id, dto));
            return Ok(new { message = "Proveedor actualizado exitosamente" });
        }

        // GET api/supplier
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Envía el query al handler de GetAllSuppliers
            var result = await _mediator.Send(new GetAllSuppliersQuery());
            return Ok(result);
        }

        // GET api/supplier/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Envía el query al handler de GetSupplierById
            var result = await _mediator.Send(new GetSupplierByIdQuery(id));
            return Ok(result);
        }

        // DELETE (SoftDelete) - Solo Administrador
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            // Envía el comando al handler de DeleteSupplier (soft delete)
            await _mediator.Send(new DeleteSupplierCommand(id));
            return Ok(new { message = "Proveedor deshabilitado (soft delete)" });
        }
    }
}