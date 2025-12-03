using Hangfire;
using MediatR;
using smartcoffe.Application.Features.Reports.DailyReservations;

namespace smartcoffe.Configuration
{
    public static class HangfireJobScheduler
    {
        public static void ScheduleRecurringJobs(IApplicationBuilder app)
        {
            // Obtenemos el RecurringJobManager del contenedor de servicios
            // Usamos IApplicationBuilder para poder resolver servicios si fuera necesario, 
            // aunque Hangfire tiene sus propios métodos estáticos, es mejor inyectar si es posible.
            
            // Opción A: Usar los métodos estáticos de Hangfire (más común y fácil)
            // Definimos el ID del trabajo como "reporte-diario-reservas"
            
            RecurringJob.AddOrUpdate<IMediator>(
                "reporte-diario-reservas",
                mediator => mediator.Send(new GenerateDailyReservationsReportCommand(), default),
                "0 11 * * *", // Cron: A las 11:00 AM todos los días
                TimeZoneInfo.Local // Importante: Usar la hora local del servidor
            );
            
            // Nota: La expresión CRON "0 11 * * *" significa: Minuto 0, Hora 11, Cualquier día, Cualquier mes, Cualquier día de la semana.
        }
    }
}