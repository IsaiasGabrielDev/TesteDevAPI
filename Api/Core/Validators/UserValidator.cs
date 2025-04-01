using Core.Entities;
using FluentValidation;

namespace Core.Validators;

internal class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("O nome é obrigatório")
            .Matches(@"^[A-Z]")
            .WithMessage("O primeiro caractere deve ser uma letra maiúscula.")
            .MaximumLength(200)
            .WithMessage("O nome não poderá exceder 200 caracteres");

        RuleFor(p => p.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("O e-mail é obrigatório")
            .EmailAddress()
            .WithMessage("O e-mail informado é inválido");

        RuleFor(p => p.Password)
            .MinimumLength(8)
            .WithMessage("A senha deve ter no mínimo 8 caracteres.")
            .Matches(@"[A-Z]")
            .WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
            .Matches(@"[\W_]")
            .WithMessage("A senha deve conter pelo menos um caractere especial.")
            .Matches(@"\d")
            .WithMessage("A senha deve conter pelo menos um número.");
    }
}
