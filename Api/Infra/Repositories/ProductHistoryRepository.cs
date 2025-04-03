using Core.Abstraction;
using Core.Entities;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal class ProductHistoryRepository(AppDbContext context) : IProductHistoryRepository
{
    private readonly AppDbContext _context = context;

    public async Task<ProductHistory> AddAsync(ProductHistory productHistory, CancellationToken cancellationToken)
    {
        var entry = await _context.ProductHistories.AddAsync(productHistory, cancellationToken);
        return entry.Entity;
    }

    public async Task<IEnumerable<ProductHistory>> GetByProductIdAsync(int productId, CancellationToken cancellationToken) =>
        await _context.ProductHistories
            .AsNoTracking()
            .Where(x => x.ProductId == productId)
            .ToListAsync(cancellationToken);

    public async Task<IEnumerable<ProductHistory>> GetByUserIdAsync(int userId, CancellationToken cancellationToken) =>
        await _context.ProductHistories
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
}
