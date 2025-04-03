using Core.Entities;

namespace Core.Abstraction;

public interface IUserRepository
{
    Task<User> AddUser(User user, CancellationToken cancellationToken);
    Task<User> GetUserByEmail(string email, CancellationToken cancellationToken);
}
