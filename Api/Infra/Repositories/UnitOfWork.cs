using Core.Abstraction;
using Infra.Data;

namespace Infra.Repositories;

internal sealed class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context ??
        throw new ArgumentNullException(nameof(_context));

    public async Task<int> CommitAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);

    public void Dispose()
    {
        _context.Dispose();
    }
}
