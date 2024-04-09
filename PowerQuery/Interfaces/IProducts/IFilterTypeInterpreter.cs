using System.Linq.Expressions;

namespace PowerQuery.Interfaces.IProducts;

public interface IFilterTypeInterpreter<T>
{
    Expression<Func<T, bool>> Interpreter();   
}