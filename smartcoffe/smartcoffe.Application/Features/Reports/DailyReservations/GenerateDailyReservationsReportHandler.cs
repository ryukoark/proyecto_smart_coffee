using MediatR;
using smartcoffe.Domain.Entities;
using smartcoffe.Domain.Interfaces;
using System.Globalization;

namespace smartcoffe.Application.Features.Reports.DailyReservations
{
    public class GenerateDailyReservationsReportHandler : IRequestHandler<GenerateDailyReservationsReportCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExcelService _excelService;

        public GenerateDailyReservationsReportHandler(IUnitOfWork unitOfWork, IExcelService excelService)
        {
            _unitOfWork = unitOfWork;
            _excelService = excelService;
        }

        public async Task<Unit> Handle(GenerateDailyReservationsReportCommand request, CancellationToken cancellationToken)
        {
            // 1. Obtener la fecha de hoy
            var today = DateOnly.FromDateTime(DateTime.Now);

            var reservationRepo = _unitOfWork.Repository<Reservation>();
            var userRepo = _unitOfWork.Repository<smartcoffe.Domain.Entities.User>(); 
            var cafeRepo = _unitOfWork.Repository<Cafe>();

            // 3. Obtener datos (Reservas de hoy)
            var reservations = await reservationRepo.FindAsync(r => r.ReservationDate == today);
            var users = await userRepo.GetAllAsync();
            var cafes = await cafeRepo.GetAllAsync();

            // 4. Preparar datos para Excel
            var headers = new List<string> 
            { 
                "Código Reserva", 
                "Fecha", 
                "Cliente", 
                "Cafetería", 
                "Estado", 
                "Notas" 
            };

            var rows = reservations.Select(r => 
            {
                var userName = users.FirstOrDefault(u => u.Id == r.IdUser)?.Name ?? "Desconocido";
                var cafeName = cafes.FirstOrDefault(c => c.Id == r.IdCafe)?.Name ?? "Desconocido";

                return new List<object>
                {
                    r.ReservationCode,
                    r.ReservationDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    userName,
                    cafeName,
                    r.ReservationStatus,
                    r.Notes ?? ""
                };
            }).ToList();

            // 5. Generar los bytes del Excel
            var fileBytes = _excelService.CreateExcel($"Reservas_{today:yyyyMMdd}", headers, rows);

            // 6. Guardar el archivo en disco ("Imprimir")
            // Definir ruta: Carpeta 'GeneratedReports' en la raíz del proyecto de ejecución
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "GeneratedReports");
            
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = $"Reporte_Reservas_{today:yyyyMMdd_HHmmss}.xlsx";
            var fullPath = Path.Combine(folderPath, fileName);

            await File.WriteAllBytesAsync(fullPath, fileBytes, cancellationToken);

            // Aquí podrías agregar lógica para enviar email, subir a S3, etc.
            Console.WriteLine($"[Hangfire] Reporte generado exitosamente: {fullPath}");

            return Unit.Value;
        }
    }
}