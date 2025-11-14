using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;

namespace smartcoffe.Application.Features.Cafes.Queries
{
    public class GetCafeById : IRequest<CafeGetDto>
    {
        public int Id { get; }

        public GetCafeById(int id)
        {
            Id = id;
        }
    }

    public class GetCafeByIdHandler : IRequestHandler<GetCafeById, CafeGetDto>
    {
        public async Task<CafeGetDto> Handle(GetCafeById request, CancellationToken cancellationToken)
        {
            var cafe = new CafeGetDto
            {
                Id = request.Id,
                Name = "Café Central",
                Adress = "Av. Central 123",
                Company = "SmartCoffee",
                Status = "Active"
            };

            return await Task.FromResult(cafe);
        }
    }
}