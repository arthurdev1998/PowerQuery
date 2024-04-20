namespace PowerQuery.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public Task<bool> Commit();
}