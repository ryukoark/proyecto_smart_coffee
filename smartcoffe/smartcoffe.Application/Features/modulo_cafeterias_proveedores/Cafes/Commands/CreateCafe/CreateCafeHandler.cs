using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.CreateCafe
{
    public class CreateCafeHandler : IRequestHandler<CreateCafeCommand, CafeGetDto>
    {
        public async Task<CafeGetDto> Handle(CreateCafeCommand request, CancellationToken cancellationToken)
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