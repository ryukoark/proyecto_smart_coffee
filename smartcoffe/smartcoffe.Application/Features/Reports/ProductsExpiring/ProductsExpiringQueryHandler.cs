using MediatR;
using smartcoffe.Domain.Entities;
using smartcoffe.Domain.Interfaces;
using System.Globalization;
using System.Linq;

namespace smartcoffe.Application.Features.Reports.ProductsExpiring
{
    public class ProductsExpiringQueryHandler : IRequestHandler<ProductsExpiringQuery, byte[]>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExcelService _excel;

        public ProductsExpiringQueryHandler(IUnitOfWork unitOfWork, IExcelService excel)
        {
            _unitOfWork = unitOfWork;
            _excel = excel;
        }

        public async Task<byte[]> Handle(ProductsExpiringQuery request, CancellationToken cancellationToken)
        {
            // Repositorio de productos
            var productRepo = _unitOfWork.Repository<Domain.Entities.Product>();
            var products = await productRepo.GetAllAsync();

            // Fecha límite
            var limit = DateOnly.FromDateTime(DateTime.Now.AddDays(request.Days));

            // Filtrar productos que expiran antes de la fecha límite
            var expiringProducts = products
                .Where(p => p.Expirationdate.HasValue && p.Expirationdate <= limit)
                .ToList();

            // Encabezados del Excel
            var headers = new List<string> { "ID", "Producto", "Precio", "Expira", "Estado" };

            // Filas del Excel
            var rows = expiringProducts.Select(p => new List<object>
            {
                p.Id,
                p.Productname,
                p.Price,
                p.Expirationdate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) ?? "",
                p.Status ? "Active" : "Inactive"
            }).ToList();

            // Generar Excel
            return _excel.CreateExcel("Expiracion", headers, rows);
        }
    }
}