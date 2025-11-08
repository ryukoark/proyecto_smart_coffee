using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using smartcoffe.Application.Features.Category.Commands;
using smartcoffe.Application.Features.Category.Queries;
using smartcoffe.Application.Promotion.Commands.CreatePromotion;
using smartcoffe.Application.Promotion.Commands.DeletePromotion;
using smartcoffe.Application.Promotion.Commands.UpdatePromotion;
using smartcoffe.Application.Promotion.Queries.PromotionGet;
using smartcoffe.Application.Promotion.Queries.PromotionGetById;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Extension;

public static class ProjectServicesExtensions
{
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.RegisterServicesFromAssembly(typeof(createPromotionHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(updatePromotionHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(deletePromotionHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(getAllPromotionsHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(getPromotionByIdHandler).Assembly);
                
                //Category
                cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateCategoryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteCategoryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllCategoriesQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCategoryByIdQueryHandler).Assembly);
                
                
            });
            return services;
        }
}