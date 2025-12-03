// File: ExpiringProductDto.cs

using System;

namespace smartcoffe.Application.Features.Reports.ProductsExpiring.DTOs
{
    public class ExpiringProductDto
    {
        public int InventoryId { get; set; }
        public string ProductName { get; set; }
        public int InventoryQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int DaysUntilExpiration { get; set; }
    }
}