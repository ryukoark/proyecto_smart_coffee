using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace smartcoffe.Configuration;

public static class ServiceRegistrationExtensions
{
    // Mantenemos solo la lógica específica de la aplicación que no sea Swagger/Controllers.
    // Si no hay más lógica, esta función queda vacía, pero debe existir para ser llamada.
    public static void AddAppServices(this IServiceCollection services, ConfigurationManager configuration, IWebHostEnvironment environment)
    {
        // Nota: La configuración de Swagger y Controllers se ha ELIMINADO de aquí 
        // y se ha movido al Program.cs para centralizar.
        // Aquí iría cualquier otro servicio de lógica de negocio o filtros.
    }

    public static void UseApp(this WebApplication app)
    {
        // Nota: La configuración de Swagger ELIMINADA de aquí y movida a Program.cs.
        // Mantenemos solo el uso de HttpsRedirection y MapControllers si no están en Program.cs.

        // Dado que Program.cs ya llama a app.UseHttpsRedirection() y app.MapControllers(), 
        // este método puede estar vacío o contener solo middleware personalizado.
    }
}