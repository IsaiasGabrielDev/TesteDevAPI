using Core.Abstraction;
using Core.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Threading;

namespace Core.Services.CategoryServices;

internal class AddCategoryHandler(IUnitOfWork unitOfWork,
    ICategoryRepository categoryRepository,
    IValidator<Category> validator)
    : IFunctionHandler<AddCategoryFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IValidator<Category> _validator = validator;

    public AddCategoryFunction HandlerFunction => Handle;

    private async Task<(Category category, string errorMessage)> Handle(AddCategoryDTO categoryDTO, CancellationToken cancellationToken)
    {
        try
        {
            Category category = new Category(categoryDTO.Name);

            ValidationResult validationResult = await _validator.ValidateAsync(category);
            if (!validationResult.IsValid)
                return (null!, validationResult.ToString());

            var addedCategory = await _categoryRepository.AddCategory(category, cancellationToken);
            var rowsAffected = await _unitOfWork.CommitAsync(cancellationToken);
            return rowsAffected > 0
                ? (addedCategory, string.Empty)
                : (null!, "Falha ao adicionar a categoria");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

public delegate Task<(Category category, string errorMessage)> 
    AddCategoryFunction(AddCategoryDTO categoryDTO, CancellationToken cancellationToken);

public sealed record AddCategoryDTO(string Name);