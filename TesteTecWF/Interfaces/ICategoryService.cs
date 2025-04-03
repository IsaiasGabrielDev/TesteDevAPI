using TesteTecWF.Models;

namespace TesteTecWF.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<IEnumerable<Category>>> GetAllCategoriesAsync();
    Task<ApiResponse<Category>> GetCategoryByIdAsync(int id);
    Task<ApiResponse<Category>> CreateCategoryAsync(Category category);
    Task<ApiResponse<Category>> UpdateCategoryAsync(Category category);
    Task<ApiResponse<bool>> DeleteCategoryAsync(int id);
}
