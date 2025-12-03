using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.UpdateCafe
{
    public class UpdateCafeCommand : IRequest<CafeGetDto>
    {
        public CafeUpdateDto Dto { get; }

        public UpdateCafeCommand(CafeUpdateDto dto)
        {
            Dto = dto;
        }
    }
}