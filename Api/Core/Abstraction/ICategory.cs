using Core.Entities;

namespace Core.Abstraction;

public interface ICategory
{
    Task<IQueryable<Category>> GetAll();
    Task<Category> GetById(int categoryId);
    Task<Category> AddCategory(Category category);
    Task UpdateCategory(Category category);
    Task DeleteCategory(Category category);
}
