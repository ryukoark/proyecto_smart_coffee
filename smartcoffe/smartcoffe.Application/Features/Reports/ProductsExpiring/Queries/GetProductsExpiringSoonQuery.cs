// File: GetProductsExpiringSoonQuery.cs

using MediatR;
using System.Collections.Generic;
using smartcoffe.Application.Features.Reports.ProductsExpiring.DTOs;

namespace smartcoffe.Application.Features.Reports.ProductsExpiring.Queries
{
    public class GetProductsExpiringSoonQuery : IRequest<List<ExpiringProductDto>>
    {
        // Se requiere el ID del café para filtrar el inventario.
        public int CafeId { get; set; } 
    }
}