using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;

namespace smartcoffe.Application.Features.Cafes.Commands.UpdateCafe
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