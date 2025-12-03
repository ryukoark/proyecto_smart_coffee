using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Application.Features.modulo_usuarios.User.Commands.CreateUser;
using smartcoffe.Application.Features.modulo_usuarios.User.Commands.DeleteUser;
using smartcoffe.Application.Features.modulo_usuarios.User.Commands.UpdateUser;
using smartcoffe.Application.Features.modulo_usuarios.User.DTOs;
using smartcoffe.Application.Features.modulo_usuarios.User.Queries.GetAllUsersQuery;
using smartcoffe.Application.Features.modulo_usuarios.User.Queries.GetUserByIdQuery;

namespace smartcoffe.Controllers // O el namespace que uses para tus controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")] // Solo Administrador tiene acceso a nivel de controlador
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // 1. Obtener todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        // 2. Obtener un usuario por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            return Ok(user);
        }

        // 3. Crear un nuevo usuario
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserDto createUserDto)
        {
            // Mapeamos el DTO del body al Comando
            var command = new CreateUserCommand
            {
                Name = createUserDto.Name,
                Phonenumber = createUserDto.Phonenumber,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                Role = createUserDto.Role
            };

            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = userId }, userId);
        }

        // 4. Actualizar usuario
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo de la petición.");
            }

            var command = new UpdateUserCommand
            {
                Id = updateUserDto.Id,
                Name = updateUserDto.Name,
                Phonenumber = updateUserDto.Phonenumber,
                Email = updateUserDto.Email,
                Role = updateUserDto.Role,
                Status = updateUserDto.Status
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound($"No se pudo actualizar, usuario {id} no encontrado.");
            }

            return NoContent(); // 204 No Content es estándar para updates exitosos
        }

        // 5. Eliminar usuario (Borrado lógico o físico según definiste en el Handler)
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound($"Usuario {id} no encontrado.");
            }

            return NoContent();
        }
    }
}