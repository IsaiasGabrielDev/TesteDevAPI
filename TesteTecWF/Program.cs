using Microsoft.Extensions.DependencyInjection;
using TesteTecWF.Handler;
using TesteTecWF.Interfaces;
using TesteTecWF.Pages;
using TesteTecWF.Services;

namespace TesteTecWF;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var serviceProvider = ConfigureServices();

        var loginForm = serviceProvider.GetRequiredService<frmLogin>();
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

        services.AddTransient<frmLogin>();
        services.AddTransient<frmRegister>();

        return services.BuildServiceProvider();
    }
}