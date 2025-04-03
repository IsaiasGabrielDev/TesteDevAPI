using TesteTecWF.Models;

namespace TesteTecWF.Interfaces;

public interface IProductHistoryService
{
    Task<ApiResponse<IEnumerable<ProductHistory>>> GetByProductIdAsync(int productId, int userId);
}
