using MediatR;

namespace smartcoffe.Application.Features.Reports.DailyReservations
{
    // Este comando no devuelve nada (Unit), simplemente ejecuta la acción de generar el archivo.
    public class GenerateDailyReservationsReportCommand : IRequest<Unit>
    {
        // No necesitamos parámetros, el handler sabrá que es para la fecha "de hoy"
    }
}