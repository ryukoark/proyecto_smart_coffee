using MediatR;
using smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.Commands
{
    public class CreateShoppingDetailCommand : IRequest<int>
    {
        public ShoppingDetailCreateDto ShoppingDetail { get; set; }

        public CreateShoppingDetailCommand(ShoppingDetailCreateDto shoppingDetail)
        {
            ShoppingDetail = shoppingDetail;
        }
    }

    public class CreateShoppingDetailCommandHandler : IRequestHandler<CreateShoppingDetailCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryService _inventoryService;

        public CreateShoppingDetailCommandHandler(IUnitOfWork unitOfWork, IInventoryService inventoryService)
        {
            _unitOfWork = unitOfWork;
            _inventoryService = inventoryService;   
        }

        public async Task<int> Handle(CreateShoppingDetailCommand request, CancellationToken cancellationToken)
        {
            
            var dto = request.ShoppingDetail;
            
            // Verificar stock
            var hasStock = await _inventoryService.CheckStockAsync(dto.Id, dto.Quantity);

            if (!hasStock)
                throw new Exception("Insufficient stock for this product.");

            // Descontar stock
            await _inventoryService.ReduceStockAsync(dto.Id, dto.Quantity);
            
            var shoppingDetail = new Domain.Entities.ShoppingDetail
            {
                IdProduct = null, // Ajusta según los datos del DTO
                Quantity = 1, // Ajusta según los datos del DTO
                Amount = 0, // Ajusta según los datos del DTO
                Status = true
            };

            await _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().AddAsync(shoppingDetail);
            await _unitOfWork.CompleteAsync();

            return shoppingDetail.Id;
        }
    }
}