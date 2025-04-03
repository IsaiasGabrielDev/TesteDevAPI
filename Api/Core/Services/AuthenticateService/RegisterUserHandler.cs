using Core.Abstraction;
using Core.Entities;
using Core.Helpers;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Core.Services.AuthenticateService;

internal sealed class RegisterUserHandler(
    IUnitOfWork unitOfWork,
    IUserRepository repository,
    IValidator<User> validator,
    ILogger<RegisterUserFunction> logger) : IFunctionHandler<RegisterUserFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _repository = repository;
    private readonly IValidator<User> _validator = validator;
    private readonly ILogger<RegisterUserFunction> _logger = logger;
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
            _logger.LogWarning("Validation failed for user registration: {Errors}", validationResult.Errors);
            return (null, validationResult.ToString());
        }

        user.Password = CryptographyHelper.HashPassword(register.Password);

        var existingUser = await _repository.GetUserByEmail(register.Email, cancellationToken);
        if (existingUser != null)
        {
            _logger.LogWarning("User already exists with email: {Email}", register.Email);
            return (null, "Usuário já cadastrado");
        }
        var addedUser = await _repository.AddUser(user, cancellationToken);
        var rowsAffected = await _unitOfWork.CommitAsync(cancellationToken);
        if (rowsAffected > 0)
            return (addedUser, string.Empty);
        else
        {
            _logger.LogWarning("Failed to register user: {User}", user);
            return (null!, "Falha ao cadastrar usuário");
        }
    }
}

public delegate Task<(User? user, string errorMessage)> RegisterUserFunction(
    RegisterUser register, CancellationToken cancellationToken);

public sealed record RegisterUser(
    string Name,
    string Email,
    string Password);
