using Core.Abstraction;
using Core.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Core.Services.CategoryServices;

internal class AddCategoryHandler(IUnitOfWork unitOfWork,
    ICategoryRepository categoryRepository,
    IValidator<Category> validator,
    ILogger<AddCategoryFunction> logger)
    : IFunctionHandler<AddCategoryFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IValidator<Category> _validator = validator;
    private readonly ILogger<AddCategoryFunction> _logger = logger;

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
            if(rowsAffected > 0)
                return (addedCategory, string.Empty);

            _logger.LogError("Failed to add category");
            return (null!, "Falha ao adicionar a categoria");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception(ex.Message);
        }
    }
}

public delegate Task<(Category category, string errorMessage)> 
    AddCategoryFunction(AddCategoryDTO categoryDTO, CancellationToken cancellationToken);

public sealed record AddCategoryDTO(string Name);