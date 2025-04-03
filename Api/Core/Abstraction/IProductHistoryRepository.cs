using Core.Entities;

namespace Core.Abstraction;

public interface IProductHistoryRepository
{
    Task<object> GetByProductIdAsync(int productId, CancellationToken cancellationToken);
    Task<object> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
    Task<ProductHistory> AddAsync(ProductHistory productHistory, CancellationToken cancellationToken);
}
