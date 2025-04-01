using Core.Abstraction;
using Core.Entities;
using Core.Services.CategoryServices;
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

            services.AddTransientFunction<AddCategoryFunction, AddCategoryHandler>();
            services.AddTransientFunction<UpdateCategoryFunction, UpdateCategoryHandler>();
            services.AddTransientFunction<GetCategoryFunction, GetCategoryHandler>();
            services.AddTransientFunction<DeleteCategoryFunction, DeleteCategoryHandler>();
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
