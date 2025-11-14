using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;

namespace smartcoffe.Application.Features.Cafes.Commands
{
    public class UpdateCafe : IRequest<CafeGetDto>
    {
        public CafeUpdateDto Dto { get; }

        public UpdateCafe(CafeUpdateDto dto)
        {
            Dto = dto;
        }
    }

    public class UpdateCafeHandler : IRequestHandler<UpdateCafe, CafeGetDto>
    {
        public async Task<CafeGetDto> Handle(UpdateCafe request, CancellationToken cancellationToken)
        {
            var updatedCafe = new CafeGetDto
            {
                Id = 1, // simulado
                Name = request.Dto.Name,
                Adress = request.Dto.Adress,
                Company = request.Dto.Company,
                Status = request.Dto.Status
            };

            return await Task.FromResult(updatedCafe);
        }
    }
}