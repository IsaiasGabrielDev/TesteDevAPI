using Core.Abstraction;
using Core.Entities;

namespace Core.Services.AuthenticateService;

internal sealed class GetUserByEmailHandler(
    IUserRepository repository) : IFunctionHandler<GetUserByEmailFunction>
{
    private readonly IUserRepository _repository = repository;

    public GetUserByEmailFunction HandlerFunction => Handle;

    private async Task<User?> Handle(string email, CancellationToken cancellationToken)
    {
        return await _repository.GetUserByEmail(email, cancellationToken);
    }
}

public delegate Task<User?> GetUserByEmailFunction(string email, CancellationToken cancellationToken);