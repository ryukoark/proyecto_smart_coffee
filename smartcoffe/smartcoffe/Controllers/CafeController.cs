using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.DTOs.Cafe;
using System;
using System.Collections.Generic;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CafeController : ControllerBase
    {
        // ======== GET: Listar todos los cafés ========
        [HttpGet]
        public ActionResult<IEnumerable<CafeListDto>> GetAll()
        {
            // Ejemplo con datos simulados
            var cafes = new List<CafeListDto>
            {
                new CafeListDto { Id = 1, Name = "Smart Coffee Central", Company = "SmartCoffe Inc", Status = "Active" },
                new CafeListDto { Id = 2, Name = "Smart Coffee Norte", Company = "SmartCoffe Inc", Status = "Inactive" }
            };

            return Ok(cafes);
        }

        // ======== GET: Obtener un café por ID ========
        [HttpGet("{id}")]
        public ActionResult<CafeGetDto> GetById(int id)
        {
            // Ejemplo simulado
            var cafe = new CafeGetDto
            {
                Id = id,
                Name = "Smart Coffee Central",
                Adress = "Av. Principal #123",
                Company = "SmartCoffe Inc",
                Status = "Active"
            };

            return Ok(cafe);
        }

        // ======== POST: Crear un nuevo café ========
        [HttpPost]
        public IActionResult Create([FromBody] CafeCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos.");

            // Lógica para guardar en la base de datos
            var newId = new Random().Next(100, 999);

            return CreatedAtAction(nameof(GetById), new { id = newId }, dto);
        }

        // ======== PUT: Actualizar un café existente ========
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CafeUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos.");

            // Lógica de actualización simulada
            return Ok(new
            {
                Message = $"Café con ID {id} actualizado correctamente.",
                UpdatedData = dto
            });
        }

        // ======== DELETE: Eliminar o desactivar un café ========
        [HttpDelete]
        public IActionResult Delete([FromBody] CafeDeleteDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest("ID inválido.");

            // Lógica simulada para eliminar o marcar como inactivo
            return Ok(new
            {
                Message = $"Café con ID {dto.Id} eliminado correctamente.",
                Reason = dto.Reason,
                DeletedBy = dto.DeletedBy,
                Status = dto.Status
            });
        }
    }
}
