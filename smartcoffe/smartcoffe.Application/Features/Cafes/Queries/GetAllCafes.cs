using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;
using System.Collections.Generic;

namespace smartcoffe.Application.Features.Cafes.Queries
{
    public class GetAllCafes : IRequest<IEnumerable<CafeListDto>>
    {
    }

    public class GetAllCafesHandler : IRequestHandler<GetAllCafes, IEnumerable<CafeListDto>>
    {
        public async Task<IEnumerable<CafeListDto>> Handle(GetAllCafes request, CancellationToken cancellationToken)
        {
            var cafes = new List<CafeListDto>
            {
                new CafeListDto { Id = 1, Name = "Café Central", Adress = "Av. Central 123", Company = "SmartCoffee", Status = "Active" },
                new CafeListDto { Id = 2, Name = "Café Norte", Adress = "Calle Norte 45", Company = "SmartCoffee", Status = "Active" }
            };

            return await Task.FromResult(cafes);
        }
    }
}