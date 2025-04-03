using Core.Abstraction;
using Core.Entities;

namespace Core.Services.CategoryServices;

internal class GetCategoryHandler(
    ICategoryRepository repository) : IFunctionHandler<GetCategoryFunction>
{
    private readonly ICategoryRepository _repository = repository;

    public GetCategoryFunction HandlerFunction => Handle;

    private async Task<(Category? category, IEnumerable<Category>? categories)> Handle(int categoryId, CancellationToken cancellationToken)
    {
        try
        {
            if(categoryId > 0)
                return (await GetCategory(categoryId, cancellationToken), null);

            return (null, await GetCategories(cancellationToken));
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    private async Task<Category?> GetCategory(int categoryId, CancellationToken cancellationToken) => 
        await _repository.GetById(categoryId, cancellationToken);

    private async Task<IEnumerable<Category>> GetCategories(CancellationToken cancellationToken) =>
        await _repository.GetAll(cancellationToken); 
}

public delegate Task<(Category? category, IEnumerable<Category>? categories)>
    GetCategoryFunction(int categoryId, CancellationToken cancellationToken);