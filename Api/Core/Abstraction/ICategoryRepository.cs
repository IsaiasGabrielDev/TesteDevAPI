using Core.Entities;

namespace Core.Abstraction;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken);
    Task<Category> GetById(int categoryId, CancellationToken cancellationToken);
    Task<Category> AddCategory(Category category, CancellationToken cancellationToken);
    Task UpdateCategory(Category category);
    Task DeleteCategory(Category category);
}
