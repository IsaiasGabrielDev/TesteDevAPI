using Infra.Data;
using Core.Abstraction;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal sealed class ProductRepository(AppDbContext context) : IProductRepository
{
    private readonly AppDbContext _context = context;

    #region Selects
    public async Task<object> GetAll(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 20)
    {
        var products = await _context.Products.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        var totalRecords = await _context.Products.AsNoTracking().CountAsync(cancellationToken);
        return new
        {
            Products = products,
            TotalRecords = totalRecords
        };
    }        

    public async Task<Product> GetById(int productId, CancellationToken cancellationToken) =>
        await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

    public async Task<object> GetProductsReportStock(CancellationToken cancellationToken)
    {
        int totalProducts = await _context.Products.AsNoTracking().CountAsync(cancellationToken);
        decimal totalStockValue = await _context.Products.AsNoTracking().SumAsync(p => p.Price, cancellationToken);
        decimal averageProductPrices = Math.Round(totalStockValue / totalProducts, 2);

        return new
        {
            TotalProducts = totalProducts,
            TotalStockValue = totalStockValue,
            AverageProductPrices = averageProductPrices
        };
    }
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
