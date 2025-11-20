using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Cafes.Queries.GetCafeByIdQuery
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
            var cafe = await _unitOfWork.Cafes.GetByIdAsync(request.Id);

            if (cafe == null)
                return null!; // Opcional: lanzar excepción NotFound

            // Mapeo manual entidad → DTO
            var cafeDto = new CafeGetDto
            {
                Id = cafe.Id,
                Name = cafe.Name,
                Adress = cafe.Address,
                Company = cafe.Company,
                Status = cafe.Status ? "Active" : "Inactive"
            };

            return cafeDto;
        }
    }
}