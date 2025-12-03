using MediatR;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.CreateCafe;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Commands.CreateCafe
{
    public class CreateCafeHandler : IRequestHandler<CreateCafeCommand, CafeGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCafeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CafeGetDto> Handle(CreateCafeCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            // Crear la entidad Cafe
            var cafe = new Cafe
            {
                Name = dto.Name,
                Address = dto.Address,
                Company = dto.Company,
                Status = true // activo por defecto
            };

            // Guardar en la base de datos usando UnitOfWork
            await _unitOfWork.Repository<Cafe>().AddAsync(cafe);
            await _unitOfWork.CompleteAsync();

            // Mapear a DTO para retornar
            var cafeDto = new CafeGetDto
            {
                Id = cafe.Id,
                Name = cafe.Name,
                Address = cafe.Address,
                Company = cafe.Company,
                Status = cafe.Status ? "Active" : "Inactive"
            };

            return cafeDto;
        }
    }
}