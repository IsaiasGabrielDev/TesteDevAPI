using Core.Abstraction;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Core.Services.AuthenticateService;

internal sealed class GetUserByEmailHandler(
    IUserRepository repository,
    ILogger<GetUserByEmailFunction> logger) : IFunctionHandler<GetUserByEmailFunction>
{
    private readonly IUserRepository _repository = repository;
    private readonly ILogger<GetUserByEmailFunction> _logger = logger;

    public GetUserByEmailFunction HandlerFunction => Handle;

    private async Task<User?> Handle(string email, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetUserByEmailHandler: Handling request to get user by email: {Email}", email);
        return await _repository.GetUserByEmail(email, cancellationToken);
    }
}

public delegate Task<User?> GetUserByEmailFunction(string email, CancellationToken cancellationToken);