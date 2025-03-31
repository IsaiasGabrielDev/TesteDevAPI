namespace Core.Abstraction;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
}
