using System.Linq.Expressions;
using PowerQuery.Builder;
using PowerQuery.Models;

namespace PowerQuery.Factorys.Interpreters.Products;

public class StartWithInterpreter<T> : FilterTypeAbstractBuilder<T>
{
    public StartWithInterpreter(FiltroItem filterItem) : base(filterItem)
    {
    }

    public override Expression CreateExpression(MemberExpression property, ConstantExpression constant)
    {
        var method = typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string) })
                                                             ?? throw new ArgumentNullException();
        
        return Expression.Call(property, method, constant);
    }
}