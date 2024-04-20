#nullable disable

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PowerQuery.Data;
using PowerQuery.Interfaces.Repository;

namespace PowerQuery.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly AppDbContext _context;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, bool asnotracking = true)
    {
        return asnotracking ?
        await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync() :
        await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> GetSomeThing(Expression<Func<T, bool>> predicate, bool asnotracking = false)
    {
        return asnotracking ?
        await _context.Set<T>().AsNoTracking().OrderBy(x => x).FirstOrDefaultAsync(predicate) :
        await _context.Set<T>().OrderBy(x => x).FirstOrDefaultAsync(predicate);
    }

    public async void Remove(T obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<T> Update(T obj)
    {
        _context.Update(obj);
        await _context.SaveChangesAsync();
        return obj;
    }
}