using Core.Abstraction;
using Core.Entities;
using Core.Helpers;
using Core.Services.AuthenticateService;
using Core.Services.CategoryServices;
using Core.Services.ProductHistoryService;
using Core.Services.ProductServices;
using Core.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core
{
    public static class ServiceProviderExtension
    {
        public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Config.IssuerToken,
                        ValidAudience = Config.AudienceToken,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Config.SecurityTokenKey))
                    };

                    option.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },

                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IValidator<Product>, ProductValidator>();
            services.AddScoped<IValidator<User>, UserValidator>();

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
            services.AddTransientFunction<GetProductsReportStockFunction, GetProductsReportStockHandler>();
            #endregion

            #region Inject User
            services.AddTransientFunction<RegisterUserFunction, RegisterUserHandler>();
            services.AddTransientFunction<LoginUserFunction, LoginUserHandler>();
            services.AddTransientFunction<GetUserByEmailFunction, GetUserByEmailHandler>();
            #endregion

            #region Inject ProductHistory
            services.AddTransientFunction<GetProductHistoryFunction, GetProductHistoryHandler>();
            services.AddTransientFunction<AddProductHistoryFunction, AddProductHistoryHandler>();
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
