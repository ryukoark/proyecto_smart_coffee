using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;
using smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.Queries
{
    public class GetAllShoppingDetailsQuery : IRequest<IEnumerable<ShoppingDetailGetDto>>
    {
    }

    public class GetAllShoppingDetailsQueryHandler : IRequestHandler<GetAllShoppingDetailsQuery, IEnumerable<ShoppingDetailGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShoppingDetailsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ShoppingDetailGetDto>> Handle(GetAllShoppingDetailsQuery request, CancellationToken cancellationToken)
        {
            var shoppingDetails = await _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().GetAllAsync();

            // Cargar catálogos relacionados en memoria para mapear eficientemente
            var products = (await _unitOfWork.Repository<Domain.Entities.Product>().GetAllAsync())
                .ToDictionary(p => p.Id, p => p);

            var shoppings = (await _unitOfWork.Repository<Domain.Entities.Shopping>().GetAllAsync())
                .ToDictionary(s => s.Id, s => s);

            // Mapear usando datos reales; BuyerName/PaymentMethod pueden no existir en la entidad,
            // por ahora devolvemos cadenas vacías si no están disponibles en la BD.
            var result = shoppingDetails.Select(s => new ShoppingDetailGetDto
            {
                Id = s.Id,
                ProductName = s.IdProduct.HasValue && products.ContainsKey(s.IdProduct.Value)
                    ? products[s.IdProduct.Value].Productname
                    : "Unknown",
                Price = s.Amount != 0 ? s.Amount :
                        (s.IdProduct.HasValue && products.ContainsKey(s.IdProduct.Value) ? products[s.IdProduct.Value].Price : 0m),
                Quantity = s.Quantity,
                PurchaseDate = s.IdShopping.HasValue && shoppings.ContainsKey(s.IdShopping.Value)
                    ? shoppings[s.IdShopping.Value].Date
                    : DateTime.Now,
                BuyerName = string.Empty,
                PaymentMethod = string.Empty,
                IdProduct = s.IdProduct,
                IdShopping = s.IdShopping
            }).ToList();

            return result;
        }
    }
}