using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Queries.GetCafesByIdQuery
{
    public class GetCafeByIdQueryHandler : IRequestHandler<GetCafeByIdQuery, CafeGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCafeByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CafeGetDto> Handle(GetCafeByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener el repositorio genérico
            var cafeRepo = _unitOfWork.Repository<Cafe>();

            // Buscar el café por ID
            var cafe = await cafeRepo.GetByIdAsync(request.Id);

            if (cafe == null)
                return null!; // El controller manejará NotFound

            // Mapear a DTO
            return new CafeGetDto
            {
                Id = cafe.Id,
                Name = cafe.Name,
                Address = cafe.Address,   // ✅ corregido
                Company = cafe.Company,
                Status = cafe.Status ? "Active" : "Inactive"
            };
        }
    }
}