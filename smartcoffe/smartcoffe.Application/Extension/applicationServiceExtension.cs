using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using smartcoffe.Application.Promotion.Commands.CreatePromotion;
using smartcoffe.Application.Promotion.Commands.DeletePromotion;
using smartcoffe.Application.Promotion.Commands.UpdatePromotion;
using smartcoffe.Application.Promotion.Queries.PromotionGet;
using smartcoffe.Application.Promotion.Queries.PromotionGetById;

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
                cfg.RegisterServicesFromAssembly(typeof(createPromotionHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(updatePromotionHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(deletePromotionHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(getAllPromotionsHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(getPromotionByIdHandler).Assembly);
            });
        }
    }
}