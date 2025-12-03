using MediatR;

namespace smartcoffe.Application.Features.Reports.InventoryByCafe
{
    public class InventoryByCafeQuery : IRequest<byte[]>
    {
        public int CafeId { get; set; }
        public InventoryByCafeQuery(int cafeId) => CafeId = cafeId;
    }
}