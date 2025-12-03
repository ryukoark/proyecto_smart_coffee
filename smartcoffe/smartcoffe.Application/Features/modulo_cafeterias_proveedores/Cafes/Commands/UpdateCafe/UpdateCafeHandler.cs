using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.UpdateCafe
{
    public class UpdateCafeHandler : IRequestHandler<UpdateCafeCommand, CafeGetDto>
    {
        public async Task<CafeGetDto> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
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