using Core.Entities;
using FluentValidation;

namespace Core.Validators;

internal class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("O nome do produto é obrigatório")
            .Matches(@"^[A-Z]")
            .WithMessage("O primeiro caractere deve ser uma letra maiúscula.")
            .MaximumLength(200)
            .WithMessage("O nome do produto não poderá exceder 200 caracteres");

        RuleFor(p => p.Price)
            .NotEqual(0)
            .WithMessage("O preço do produto não poderá ser zero")
            .PrecisionScale(10, 2, true);

        RuleFor(p => p.CategoryId)
            .NotNull()
            .NotEmpty()
            .NotEqual(0)
            .WithMessage("Informe o código da categoria");
    }
}
