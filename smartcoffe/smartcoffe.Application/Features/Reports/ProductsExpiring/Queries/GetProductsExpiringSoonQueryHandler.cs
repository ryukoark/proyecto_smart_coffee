// File: GetProductsExpiringSoonQueryHandler.cs - CORREGIDO

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities; 
using smartcoffe.Application.Features.Reports.ProductsExpiring.DTOs;

namespace smartcoffe.Application.Features.Reports.ProductsExpiring.Queries
{
    public class GetProductsExpiringSoonQueryHandler 
        : IRequestHandler<GetProductsExpiringSoonQuery, List<ExpiringProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        // El umbral de expiración (30 días)
        private const int ExpirationDaysThreshold = 30;

        public GetProductsExpiringSoonQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ExpiringProductDto>> Handle(
            GetProductsExpiringSoonQuery request, 
            CancellationToken cancellationToken)
        {
            // 1. Obtener los repositorios de las entidades necesarias
            var inventoryRepo = _unitOfWork.Repository<Inventory>();
            var productRepo = _unitOfWork.Repository<Product>();

            var inventories = await inventoryRepo.GetAllAsync(); 
            var products = await productRepo.GetAllAsync();

            var expirationThreshold = DateTime.Now.AddDays(ExpirationDaysThreshold).Date;
            
            var expiringProducts = inventories
                // 1. Filtrar el inventario por la cafetería solicitada
                .Where(i => i.IdCafe == request.CafeId)
                // 2. Unir con la colección de productos
                .Join(products, 
                    inventory => inventory.IdProduct,
                    product => product.Id,
                    (inventory, product) => new { inventory, product })
                // 3. Filtrar: Producto debe tener fecha de expiración y debe ser menor o igual al umbral
                .Where(temp => temp.product.Expirationdate.HasValue &&
                               temp.product.Expirationdate.Value.ToDateTime(TimeOnly.MinValue) <= expirationThreshold)
                // 4. Proyectar al DTO final
                .Select(temp => new ExpiringProductDto 
                {
                    InventoryId = temp.inventory.Id,
                    ProductName = temp.product.Productname,
                    InventoryQuantity = temp.inventory.Quantity,
                    // *** LA LÍNEA CORREGIDA ESTÁ AQUÍ ***
                    ExpirationDate = temp.product.Expirationdate!.Value.ToDateTime(TimeOnly.MinValue), 
                    // Calcular los días restantes
                    DaysUntilExpiration = (int)(temp.product.Expirationdate!.Value.ToDateTime(TimeOnly.MinValue) - DateTime.Now.Date).TotalDays
                })
                .OrderBy(dto => dto.ExpirationDate)
                .ToList();

            return expiringProducts;
        }
    }
}