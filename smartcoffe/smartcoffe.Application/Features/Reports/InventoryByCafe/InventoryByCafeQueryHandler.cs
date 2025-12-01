using MediatR;
using smartcoffe.Domain.Entities;
using smartcoffe.Domain.Interfaces;
using System.Linq;

namespace smartcoffe.Application.Features.Reports.InventoryByCafe
{
    public class InventoryByCafeQueryHandler : IRequestHandler<InventoryByCafeQuery, byte[]>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExcelService _excel;

        public InventoryByCafeQueryHandler(IUnitOfWork unitOfWork, IExcelService excel)
        {
            _unitOfWork = unitOfWork;
            _excel = excel;
        }

        public async Task<byte[]> Handle(InventoryByCafeQuery request, CancellationToken cancellationToken)
        {
            // Repositorios
            var inventoryRepo = _unitOfWork.Repository<Domain.Entities.Inventory>();
            var productRepo = _unitOfWork.Repository<Domain.Entities.Product>();
            var supplierRepo = _unitOfWork.Repository<Domain.Entities.Supplier>();

            // Obtener datos
            var inventory = await inventoryRepo.FindAsync(i => i.IdCafe == request.CafeId);
            var products = await productRepo.GetAllAsync();
            var suppliers = await supplierRepo.GetAllAsync();

            // Encabezados del Excel
            var headers = new List<string> { "ID", "Producto", "Cantidad", "Proveedor", "Estado" };

            // Filas
            var rows = inventory.Select(x =>
            {
                var productName = products.FirstOrDefault(p => p.Id == x.IdProduct)?.Productname ?? "Producto desconocido";
                var supplierName = suppliers.FirstOrDefault(s => s.Id == x.IdSupplier)?.Name ?? "Proveedor desconocido";

                return new List<object>
                {
                    x.Id,
                    productName,
                    x.Quantity,
                    supplierName,
                    x.Status ? "Active" : "Inactive"
                };
            }).ToList();

            // Crear Excel
            return _excel.CreateExcel("Inventario", headers, rows);
        }
    }
}
