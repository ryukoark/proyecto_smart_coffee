using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;
using smartcoffe.Domain.Interfaces;

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
            // Repositorio genérico
            var cafeRepo = _unitOfWork.Repository<Domain.Entities.Cafe>();

            var cafe = await cafeRepo.GetByIdAsync(request.Id);

            if (cafe == null)
                return null!;

            return new CafeGetDto
            {
                Id = cafe.Id,
                Name = cafe.Name,
                Adress = cafe.Address,
                Company = cafe.Company,
                Status = cafe.Status ? "Active" : "Inactive"
            };
        }
    }
}