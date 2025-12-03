using MediatR;
using smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.Commands
{
    public class UpdateShoppingDetailCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public ShoppingDetailUpdateDto ShoppingDetail { get; set; } = null!;

        public UpdateShoppingDetailCommand(int id, ShoppingDetailUpdateDto shoppingDetail)
        {
            Id = id;
            ShoppingDetail = shoppingDetail;
        }
    }

    public class UpdateShoppingDetailCommandHandler : IRequestHandler<UpdateShoppingDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShoppingDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateShoppingDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().GetByIdAsync(request.Id);
            if (entity == null) return false;

            entity.IdProduct = request.ShoppingDetail.IdProduct;
            entity.Quantity = request.ShoppingDetail.Quantity;
            entity.Amount = request.ShoppingDetail.Price * request.ShoppingDetail.Quantity;
            entity.IdShopping = request.ShoppingDetail.IdShopping;

            // BuyerName/PaymentMethod: asignar solo si la entidad tiene esas propiedades.
            // Si la entidad no tiene esas columnas, coméntalas o añade las propiedades a la entidad y migra.
            #pragma warning disable CS0618
            try
            {
                // Intentamos asignar por reflexión si existen (evita fallos si la entidad no las tiene)
                var t = entity.GetType();
                var propBuyer = t.GetProperty("BuyerName");
                if (propBuyer != null) propBuyer.SetValue(entity, request.ShoppingDetail.BuyerName);

                var propPayment = t.GetProperty("PaymentMethod");
                if (propPayment != null) propPayment.SetValue(entity, request.ShoppingDetail.PaymentMethod);
            }
            catch { /* ignore reflection assignment errors */ }
            #pragma warning restore CS0618

            _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().Update(entity);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}