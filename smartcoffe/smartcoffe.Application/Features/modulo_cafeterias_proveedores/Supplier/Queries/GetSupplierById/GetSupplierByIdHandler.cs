using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Queries.GetSupplierById
{
    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSupplierByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _unitOfWork.Repository<Domain.Entities.Supplier>().GetByIdAsync(request.Id);

            if (supplier == null || !supplier.Status)
            {
                throw new KeyNotFoundException($"Proveedor con ID {request.Id} no encontrado o está inactivo.");
            }

            // Mapeamos al DTO detallado
            var dto = new SupplierDto
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                Phone = supplier.Phone,
                Email = supplier.Email,
                Status = supplier.Status
            };

            return dto;
        }
    }
}