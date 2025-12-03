using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.CreateCafe
{
    public class CreateCafeCommand : IRequest<CafeGetDto>
    {
        public CafeCreateDto Dto { get; set; }

        public CreateCafeCommand(CafeCreateDto dto)
        {
            Dto = dto;
        }
    }
}