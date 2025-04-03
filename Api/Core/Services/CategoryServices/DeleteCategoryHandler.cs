using Core.Abstraction;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Core.Services.CategoryServices;

internal class DeleteCategoryHandler(
    IUnitOfWork unitOfWork,
    ICategoryRepository repository,
    ILogger<DeleteCategoryFunction> logger) : IFunctionHandler<DeleteCategoryFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICategoryRepository _repository = repository;
    private readonly ILogger<DeleteCategoryFunction> _logger = logger;

    public DeleteCategoryFunction HandlerFunction => Handle;

    private async Task<(bool isDelete, string errorMessage)> Handle(int categoryId, CancellationToken cancellationToken)
    {
        try
        {
            Category category = await _repository.GetById(categoryId, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("Categoria não encontrada: {categoryId}", categoryId);
                return (false, "Categoria não encontrada");
            }

            if (await DeleteCategory(category, cancellationToken) > 0)
                return (true, string.Empty);

            _logger.LogWarning("Falha ao deletar a categoria: {categoryId}", categoryId);
            return (false, "Falha ao deletar a categoria");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private async Task<int> DeleteCategory(Category category, CancellationToken cancellationToken)
    {
        await _repository.DeleteCategory(category);
        return await _unitOfWork.CommitAsync(cancellationToken);
    }
}

public delegate Task<(bool isDelete, string errorMessage)> DeleteCategoryFunction(
    int categoryId, CancellationToken cancellationToken);