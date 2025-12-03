using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Queries.GetAllSuppliers
{
    public class GetAllSuppliersHandler : IRequestHandler<GetAllSuppliersQuery, IEnumerable<SupplierListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSuppliersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SupplierListDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _unitOfWork.Repository<Domain.Entities.Supplier>().GetAllAsync();

            // Filtramos solo los activos y mapeamos al DTO ligero
            var activeSuppliersDto = suppliers
                .Where(s => s.Status == true)
                .Select(s => new SupplierListDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Phone = s.Phone,
                    Email = s.Email,
                    Status = s.Status
                })
                .ToList();

            return activeSuppliersDto;
        }
    }
}