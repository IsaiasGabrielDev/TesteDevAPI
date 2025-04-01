using Core.Abstraction;
using Core.Entities;

namespace Core.Services.CategoryServices;

internal class DeleteCategoryHandler(
    IUnitOfWork unitOfWork,
    ICategoryRepository repository) : IFunctionHandler<DeleteCategoryFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICategoryRepository _repository = repository;
    public DeleteCategoryFunction HandlerFunction => Handle;

    private async Task<(bool isDelete, string errorMessage)> Handle(int categoryId, CancellationToken cancellationToken)
    {
        try
        {
            Category category = await _repository.GetById(categoryId, cancellationToken);
            if (category is null)
                return (false, "Categoria não encontrada");

            if (await DeleteCategory(category, cancellationToken) > 0)
                return (true, string.Empty);

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