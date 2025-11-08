using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace smartcoffe.Application.Extension;

public class applicationServiceExtension
{
    public static class ProjectServicesExtensions
    {
        public static void AddProjectServices(IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}