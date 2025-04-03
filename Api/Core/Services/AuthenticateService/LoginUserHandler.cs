using Core.Abstraction;
using Core.Helpers;
using Core.Services.AuthenticateService.Token;
using Microsoft.Extensions.Logging;

namespace Core.Services.AuthenticateService;

internal sealed class LoginUserHandler(
    IUserRepository repository,
    ILogger<LoginUserFunction> logger) : IFunctionHandler<LoginUserFunction>
{
    private readonly IUserRepository _repository = repository;
    private readonly ILogger<LoginUserFunction> _logger = logger;

    public LoginUserFunction HandlerFunction => Handle;

    private async Task<LoginResponse> Handle(Login login, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByEmail(login.Email, cancellationToken);
        if (user is null)
        {
            _logger.LogWarning("LoginUserHandler: User not found for email: {Email}", login.Email);
            return new LoginResponse(false, "Usuário não encontrado");
        }

        if (!CryptographyHelper.VerifyPassword(login.Password, user.Password!))
        {
            _logger.LogWarning("LoginUserHandler: Incorrect password for email: {Email}", login.Email);
            return new LoginResponse(false, "Senha incorreta");
        }

        var token = new TokenJwtBuilder()
            .AddSecurityKey(JwtSecurityKey.Create(Config.SecurityTokenKey))
            .AddSubject("NineShed V1")
            .AddIssuer(Config.IssuerToken)
            .AddAudience(Config.AudienceToken)
            .AddName(user.Name!)
            .AddEmail(user.Email!)
            .AddExpiry(1440)
            .Builder();

        return new LoginResponse(true, token.vaule);
    }
}

public delegate Task<LoginResponse> LoginUserFunction
    (Login login, CancellationToken cancellationToken);

public sealed record class Login(
    string Email,
    string Password);

public sealed record class LoginResponse(
    bool Status,
    string Token);