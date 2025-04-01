using Infra.Data;
using Core.Abstraction;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal sealed class ProductRepository(AppDbContext context) : IProductRepository
{
    private readonly AppDbContext _context = context;

    #region Selects
    public async Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 20) =>
    await _context.Products
        .OrderBy(p => p.Name)
        .Skip((pageSize - 1) * pageSize)
        .Take(pageSize)
        .AsNoTracking()
        .ToListAsync(cancellationToken);

    public async Task<Product> GetById(int productId, CancellationToken cancellationToken) =>
        await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
    #endregion

    #region Insert
    public async Task<Product> AddProduct(Product product, CancellationToken cancellationToken)
    {
        var response = await _context.Products.AddAsync(product, cancellationToken);
        return response.Entity;
    }
    #endregion

    #region Update
    public async Task UpdateProduct(Product product) =>
        await Task.Run(() => _context.Products.Update(product));
    #endregion

    #region Delete
    public async Task DeleteProduct(Product product) =>
        await Task.Run(() => _context.Products.Remove(product));
    #endregion

}
