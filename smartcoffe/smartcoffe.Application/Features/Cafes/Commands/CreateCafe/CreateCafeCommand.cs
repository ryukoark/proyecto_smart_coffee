using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;

namespace smartcoffe.Application.Features.Cafes.Commands.CreateCafe
{
    public class CreateCafeCommand : IRequest<CafeGetDto>
    {
        public CafeCreateDto Dto { get; }

        public CreateCafeCommand(CafeCreateDto dto)
        {
            Dto = dto;
        }
    }
}