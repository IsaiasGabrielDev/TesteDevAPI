using Core.Entities;

namespace Core.Abstraction;

public interface IProductHistoryRepository
{
    Task<IEnumerable<ProductHistory>> GetByProductIdAsync(int productId, CancellationToken cancellationToken);
    Task<IEnumerable<ProductHistory>> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
    Task<ProductHistory> AddAsync(ProductHistory productHistory, CancellationToken cancellationToken);
}
