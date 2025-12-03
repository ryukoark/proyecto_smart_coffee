using MediatR;

namespace smartcoffe.Application.Features.Reports.ReservationsByCafe
{
    public class ReservationsByCafeQuery : IRequest<byte[]>
    {
        public int CafeId { get; set; }
        public ReservationsByCafeQuery(int cafeId) => CafeId = cafeId;
    }
}