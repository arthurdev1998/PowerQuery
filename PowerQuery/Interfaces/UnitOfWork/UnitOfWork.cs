using PowerQuery.Data;

namespace PowerQuery.Interfaces.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
                _context.Dispose();
        }

        disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}