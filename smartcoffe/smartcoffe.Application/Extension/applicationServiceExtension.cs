using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using smartcoffe.Application.Features.Cafes.Queries.GetAllCafesQuery;
using smartcoffe.Application.Features.Category.Commands.CreateCategory;
using smartcoffe.Application.Features.Category.Commands.DeleteCategory;
using smartcoffe.Application.Features.Category.Commands.UpdateCategory;
using smartcoffe.Application.Features.Category.Queries.GetAllCategoriesQuery;
using smartcoffe.Application.Features.Category.Queries.GetCategoryByIdQuery;
using smartcoffe.Application.Features.Product.Commands.CreateProduct;
using smartcoffe.Application.Features.Product.Commands.DeleteProduct;
using smartcoffe.Application.Features.Product.Commands.UpdateProduct;
using smartcoffe.Application.Features.Product.Queries.GetProductById;
using smartcoffe.Application.Features.Promotion.Commands.CreatePromotion;
using smartcoffe.Application.Features.Promotion.Commands.DeletePromotion;
using smartcoffe.Application.Features.Promotion.Queries.GetByIdPromotion;
using smartcoffe.Application.Features.Promotion.Queries.GetPromotion;
using smartcoffe.Application.Promotion.Commands.UpdatePromotion;
using smartcoffe.Application.Features.Product.Queries.GetAllProducts; 
using smartcoffe.Application.Features.Supplier.Commands.CreateSupplier;
using smartcoffe.Application.Features.Supplier.Commands.DeleteSupplier;
using smartcoffe.Application.Features.Supplier.Commands.UpdateSupplier;
using smartcoffe.Application.Features.Supplier.Queries.GetSupplier;
using smartcoffe.Application.Features.Supplier.Queries.GetByIdSupplier;

namespace smartcoffe.Application.Extension;

public static class ProjectServicesExtensions
{
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.RegisterServicesFromAssembly(typeof(CreatePromotionHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(updatePromotionHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeletePromotionHandler).Assembly);
                
                cfg.RegisterServicesFromAssembly(typeof(GetAllPromotionsHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetPromotionByIdHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllCafesQueryHandler).Assembly);
                // --- Handlers de Categoría (Añadidos) ---
                // Commands
                cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteCategoryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateCategoryCommandHandler).Assembly);
            
                // Queries
                cfg.RegisterServicesFromAssembly(typeof(GetAllCategoriesQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCategoryByIdQueryHandler).Assembly);
                // --- Handlers de Producto (Añadidos) ---
                // Commands
                cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteProductHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateProductHandler).Assembly);
            
                // Queries
                cfg.RegisterServicesFromAssembly(typeof(GetProductByIdHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllProductsHandler).Assembly); 
                
                // --- Handlers de Supplier (AÑADIDOS) ---
                // Commands
                cfg.RegisterServicesFromAssembly(typeof(CreateSupplierHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteSupplierHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateSupplierHandler).Assembly);
            
                // Queries
                cfg.RegisterServicesFromAssembly(typeof(GetAllSuppliersHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetSupplierByIdHandler).Assembly);

            });
            return services;
        }
}