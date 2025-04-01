using Core.Abstraction;
using Core.Entities;
using Core.Services.CategoryServices;
using Core.Services.ProductServices;
using Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceProviderExtension
    {
        public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IValidator<Product>, ProductValidator>();

            #region Inject Category
            services.AddTransientFunction<AddCategoryFunction, AddCategoryHandler>();
            services.AddTransientFunction<UpdateCategoryFunction, UpdateCategoryHandler>();
            services.AddTransientFunction<GetCategoryFunction, GetCategoryHandler>();
            services.AddTransientFunction<DeleteCategoryFunction, DeleteCategoryHandler>();
            #endregion

            #region Inject Product
            services.AddTransientFunction<GetProductFunction, GetProductHandler>();
            services.AddTransientFunction<AddProductFunction, AddProductHandler>();
            services.AddTransientFunction<UpdateProductFunction, UpdateProductHandler>();
            services.AddTransientFunction<DeleteProductFunction, DeleteProductHandler>();
            #endregion
            return services;
        }

        public static IServiceCollection AddTransientFunction<TDelegate, THandler>(this IServiceCollection services)
        where THandler : IFunctionHandler<TDelegate>
        where TDelegate : Delegate
        {
            services.AddTransient(typeof(THandler));
            services.AddTransient(typeof(TDelegate), s => ((THandler)s.GetRequiredService(typeof(THandler)))!.HandlerFunction!);
            return services;
        }
    }
}
