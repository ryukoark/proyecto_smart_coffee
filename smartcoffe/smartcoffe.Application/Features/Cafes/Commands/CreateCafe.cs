using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;

namespace smartcoffe.Application.Features.Cafes.Commands
{
    public class CreateCafe : IRequest<CafeGetDto>
    {
        public CafeCreateDto Dto { get; }

        public CreateCafe(CafeCreateDto dto)
        {
            Dto = dto;
        }
    }

    public class CreateCafeHandler : IRequestHandler<CreateCafe, CafeGetDto>
    {
        public async Task<CafeGetDto> Handle(CreateCafe request, CancellationToken cancellationToken)
        {
            var cafe = new CafeGetDto
            {
                Id = 1, // simulado
                Name = request.Dto.Name,
                Adress = request.Dto.Adress,
                Company = request.Dto.Company,
                Status = "Active"
            };

            return await Task.FromResult(cafe);
        }
    }
}