using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Cafes.Queries.GetAllCafesQuery
{
    public class GetAllCafesQueryHandler : IRequestHandler<GetAllCafesQuery, IEnumerable<CafeListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCafesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CafeListDto>> Handle(GetAllCafesQuery request, CancellationToken cancellationToken)
        {
            var cafes = await _unitOfWork.Cafes.GetAllAsync();

            var cafesDto = cafes.Select(c => new CafeListDto
            {
                Id = c.Id,
                Name = c.Name,
                Adress = c.Address,
                Company = c.Company,
                Status = c.Status ? "Active" : "Inactive"
            });

            return cafesDto;
        }
    }
}