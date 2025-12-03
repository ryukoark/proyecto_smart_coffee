using MediatR;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.UpdateCafe;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.UpdateCafe
{
    public class UpdateCafeHandler : IRequestHandler<UpdateCafeCommand, CafeGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCafeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CafeGetDto> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            // Buscar el café en la DB
            var cafe = await _unitOfWork.Repository<Cafe>().GetByIdAsync(dto.Id);
            if (cafe == null)
                return null; // Se maneja en el controller como NotFound

            // Actualizar campos
            cafe.Name = dto.Name;
            cafe.Address = dto.Address;
            cafe.Company = dto.Company;
            cafe.Status = dto.Status;

            // Guardar cambios
            await _unitOfWork.CompleteAsync();

            // Mapear a DTO
            return new CafeGetDto
            {
                Id = cafe.Id,
                Name = cafe.Name,
                Address = cafe.Address,
                Company = cafe.Company,
                Status = cafe.Status ? "Active" : "Inactive"
            };
        }
    }
}
