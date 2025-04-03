using Core.Abstraction;
using Core.Entities;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal sealed class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    private readonly AppDbContext _context = context;

    #region Selects
    public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken) => 
        await _context.Categories.AsNoTracking().ToListAsync();

    public async Task<Category> GetById(int categoryId, CancellationToken cancellationToken) =>
        await _context.Categories
        .AsNoTracking()
        .Include(p => p.Products)
        .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);
    #endregion

    #region Insert
    public async Task<Category> AddCategory(Category category, CancellationToken cancellationToken)
    {
        var response = await _context.Categories.AddAsync(category, cancellationToken);
        return response.Entity;
    }
    #endregion

    #region Update
    public async Task UpdateCategory(Category category) =>
        await Task.Run(() => _context.Categories.Update(category));
    #endregion

    #region Delete
    public async Task DeleteCategory(Category category) => 
        await Task.Run(() => _context.Categories.Remove(category));
    #endregion
}
