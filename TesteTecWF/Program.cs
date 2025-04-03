using Microsoft.Extensions.DependencyInjection;
using TesteTecWF.Handler;
using TesteTecWF.Interfaces;
using TesteTecWF.Pages;
using TesteTecWF.Reports;
using TesteTecWF.Reports.ProductStockReport;
using TesteTecWF.Services;
using TesteTecWF.Strategy;

namespace TesteTecWF;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var serviceProvider = ConfigureServices();

        var loginForm = serviceProvider.GetRequiredService<frmLogin>();
        serviceProvider.GetRequiredService<frmRegister>();
        serviceProvider.GetRequiredService<frmListProduct>();
        serviceProvider.GetRequiredService<frmProduct>();
        serviceProvider.GetRequiredService<frmCategory>();
        serviceProvider.GetRequiredService<frmCategoryDetails>();
        serviceProvider.GetRequiredService<frmProductHistoryReport>();
        serviceProvider.GetRequiredService<frmProductStock>();

        Application.Run(loginForm);
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<TokenService>();

        services.AddTransient<AuthHttpClientHandler>();

        services.AddHttpClient("AuthClient");

        services.AddHttpClient("ApiClient")
            .AddHttpMessageHandler<AuthHttpClientHandler>();

        services.AddTransient<IAuthService, AuthService>(provider =>
        {
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("AuthClient");
            var tokenService = provider.GetRequiredService<TokenService>();
            return new AuthService(httpClient, tokenService);
        });

        services.AddTransient<IProductService, ProductService>(provider =>
        {
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("ApiClient");
            return new ProductService(httpClient);
        });

        services.AddTransient<ICategoryService, CategoryService>(provider =>
        {
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("ApiClient");
            return new CategoryService(httpClient);
        });
        
        services.AddTransient<IProductHistoryService, ProductHistoryService>(provider =>
        {
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("ApiClient");
            return new ProductHistoryService(httpClient);
        });

        services.AddTransient<IRenderReports, RenderReport>();

        services.AddTransient<frmLogin>();
        services.AddTransient<frmRegister>();
        services.AddTransient<frmListProduct>();
        services.AddTransient<frmProduct>();
        services.AddTransient<frmCategory>();
        services.AddTransient<frmCategoryDetails>();
        services.AddTransient<frmProductHistoryReport>();
        services.AddTransient<frmProductStock>();
        services.AddSingleton<IServiceProvider>(sp => sp);

        return services.BuildServiceProvider();
    }

}