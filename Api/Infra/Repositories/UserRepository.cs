using Core.Abstraction;
using Core.Entities;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal sealed class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    #region Selects
    public async Task<User> GetUserByEmail(string email, CancellationToken cancellationToken) =>
        await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    #endregion

    #region Insert
    public async Task<User> AddUser(User user, CancellationToken cancellationToken)
    {
        var response = await _context.Users.AddAsync(user, cancellationToken);
        return response.Entity;
    }
    #endregion
}
