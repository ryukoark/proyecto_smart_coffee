using MediatR;
using smartcoffe.Domain.Entities;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Reports.ReservationsByCafe
{
    public class ReservationDetailsQueryHandler : IRequestHandler<ReservationsByCafeQuery, byte[]>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExcelService _excel;

        public ReservationDetailsQueryHandler(IUnitOfWork unitOfWork, IExcelService excel)
        {
            _unitOfWork = unitOfWork;
            _excel = excel;
        }

        public async Task<byte[]> Handle(ReservationsByCafeQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<ReservationDetail>();

            var details = await repo.GetAllAsync();

            var headers = new List<string> { "ID Detalle", "ID Reserva", "ID Producto", "Cantidad", "Descripción" };

            var rows = details.Select(d => new List<object>
            {
                d.Id,
                d.IdReservation,
                d.IdProduct ?? 0, // manejamos nulos
                d.Quantity ?? 0,
                d.DetailDescription ?? ""
            }).ToList();

            return _excel.CreateExcel("DetallesReservas", headers, rows);
        }
    }
}