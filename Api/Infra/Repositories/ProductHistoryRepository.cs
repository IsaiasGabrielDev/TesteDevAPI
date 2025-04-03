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

    public async Task<object> GetByProductIdAsync(int productId, CancellationToken cancellationToken)
    {
        return await (from ph in _context.ProductHistories
                      join p in _context.Products on ph.ProductId equals p.Id
                      join u in _context.Users on ph.UserId equals u.Id
                      where ph.ProductId == productId
                      select new
                      {
                          DateChange = ph.DateChange,
                          LastPrice = ph.LastPrice,
                          ProductId = ph.ProductId,
                          UserName = u.Name,
                          ProductName = p.Name
                      }).ToListAsync(cancellationToken);
    }

    public async Task<object> GetByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await (from ph in _context.ProductHistories
                      join p in _context.Products on ph.ProductId equals p.Id
                      join u in _context.Users on ph.UserId equals u.Id
                      where ph.UserId == userId
                      select new
                      {
                          DateChange = ph.DateChange,
                          LastPrice = ph.LastPrice,
                          ProductId = ph.ProductId,
                          UserName = u.Name,
                          ProductName = p.Name
                      }).ToListAsync(cancellationToken);
    }
}
