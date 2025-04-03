using TesteTecWF.Models;

namespace TesteTecWF.Interfaces;

public interface IProductHistoryService
{
    Task<ApiResponse<User>> GetUserByEmail(string email);
    Task<ApiResponse<IEnumerable<ProductHistory>>> GetByProductIdAsync(int categoryId, int userId);
}
