using System.Linq.Expressions;

namespace PowerQuery.Interfaces.Repository;

public interface IRepositoryBase<T>
{   
    public Task<IEnumerable<T>> GetAll(Expression<Func<T,bool>>? predicate = null, bool asnotracking = false);
    public Task<T> GetSomeThing(Expression<Func<T, bool>>? predicate = null, bool asnotracking = false);
    public Task<T> Update(T obj);
    public void Remove(T obj);
}