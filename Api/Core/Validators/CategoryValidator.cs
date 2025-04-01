using Core.Entities;
using FluentValidation;

namespace Core.Validators;

internal class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("O nome da categoria é obrigatório")
            .Matches(@"^[A-Z]")
            .WithMessage("O primeiro caractere deve ser uma letra maiúscula.")
            .MaximumLength(100)
            .WithMessage("O nome da categoria não poderá exceder 100 caracteres");
    }
}
