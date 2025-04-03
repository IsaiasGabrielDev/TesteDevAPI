using Core.Abstraction;
using Core.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Services.CategoryServices;

internal sealed class UpdateCategoryHandler(IUnitOfWork unitOfWork,
    ICategoryRepository categoryRepository,
    IValidator<Category> validator)
    : IFunctionHandler<UpdateCategoryFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IValidator<Category> _validator = validator;
    public UpdateCategoryFunction HandlerFunction => Handle;

    private async Task<(Category category, string errorMessage)> Handle(Category categoryEdit, CancellationToken cancellationToken)
    {
        try
        {
            Category category = await _categoryRepository.GetById(categoryEdit.Id, cancellationToken);
            if (category is null)
                return (null!, "Categoria não encontrada");

            category.Name = categoryEdit.Name;
            ValidationResult validationResult = await _validator.ValidateAsync(category);

            if (!validationResult.IsValid)
                return (null!, validationResult.ToString());

            await _categoryRepository.UpdateCategory(category);

            var rowsAffected = await _unitOfWork.CommitAsync(cancellationToken);
            return rowsAffected > 0
                ? (category, string.Empty)
                : (null!, "Falha ao atualizar categoria");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

public delegate Task<(Category category, string errorMessage)>
    UpdateCategoryFunction(Category categoryEdit, CancellationToken cancellationToken);