using Core.Abstraction;
using Core.Entities;
using Core.Helpers;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Services.AuthenticateService;

internal sealed class RegisterUserHandler(
    IUnitOfWork unitOfWork,
    IUserRepository repository,
    IValidator<User> validator) : IFunctionHandler<RegisterUserFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _repository = repository;
    private readonly IValidator<User> _validator = validator;
    public RegisterUserFunction HandlerFunction => Handle;

    private async Task<(User? user, string errorMessage)> Handle(RegisterUser register, CancellationToken cancellationToken)
    {
        User user = new()
        {
            Name = register.Name,
            Email = register.Email,
            Password = register.Password
        };

        ValidationResult validationResult = await _validator.ValidateAsync(user, cancellationToken);
        if (!validationResult.IsValid)
        {
            return (null, validationResult.ToString());
        }

        user.Password = CryptographyHelper.HashPassword(register.Password);

        var existingUser = await _repository.GetUserByEmail(register.Email, cancellationToken);
        if (existingUser != null)
        {
            return (null, "Usuário já cadastrado");
        }
        var addedUser = await _repository.AddUser(user, cancellationToken);
        var rowsAffected = await _unitOfWork.CommitAsync(cancellationToken);
        return rowsAffected > 0 
            ? (addedUser, string.Empty)
            : (null!, "Falha ao cadastrar usuário");
    }
}

public delegate Task<(User? user, string errorMessage)> RegisterUserFunction(
    RegisterUser register, CancellationToken cancellationToken);

public sealed record RegisterUser(
    string Name,
    string Email,
    string Password);
