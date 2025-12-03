using MediatR;
using smartcoffe.Domain.Entities; // ✅ Importante para evitar errores de namespace
using smartcoffe.Domain.Interfaces;
using System.Linq;

namespace smartcoffe.Application.Features.Reports.TopProducts
{
    public class TopProductsQueryHandler : IRequestHandler<TopProductsQuery, byte[]>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExcelService _excel;

        public TopProductsQueryHandler(IUnitOfWork unitOfWork, IExcelService excel)
        {
            _unitOfWork = unitOfWork;
            _excel = excel;
        }

        public async Task<byte[]> Handle(TopProductsQuery request, CancellationToken cancellationToken)
        {
            var shoppingRepo = _unitOfWork.Repository<Domain.Entities.ShoppingDetail>();
            var productRepo = _unitOfWork.Repository<Domain.Entities.Product>();

            var shoppingDetails = await shoppingRepo.GetAllAsync();
            var products = await productRepo.GetAllAsync();

            var top = shoppingDetails
                .GroupBy<Domain.Entities.ShoppingDetail, int?>(sd => sd.IdProduct) // IdProduct es nullable
                .Select(g => new
                {
                    ProductId = g.Key ?? 0, // Convertimos nullable a int
                    TotalQuantity = g.Sum(x => x.Quantity) // Quantity es int
                })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(request.Limit)
                .ToList();

            var topWithNames = top.Select(t =>
            {
                var product = products.FirstOrDefault(p => p.Id == t.ProductId);
                var name = product != null ? product.Productname : "Producto desconocido";
                return new
                {
                    Name = name,
                    t.TotalQuantity
                };
            }).ToList();

            var headers = new List<string> { "Producto", "Cantidad Vendida" };

            var rows = topWithNames.Select(t => new List<object>
            {
                t.Name,
                t.TotalQuantity
            }).ToList();

            return _excel.CreateExcel("MasVendidos", headers, rows);
        }
    }
}
