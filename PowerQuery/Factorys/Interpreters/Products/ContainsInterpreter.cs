using System.Linq.Expressions;
using PowerQuery.Builder;
using PowerQuery.Models;

namespace PowerQuery.Factorys.Interpreters.Products;

public class ContainsInterpreter<T> : FilterTypeAbstractBuilder<T>
{
    private readonly FiltroItem _filtroItem;

    public ContainsInterpreter(FiltroItem filtroItem) : base(filtroItem)
    {
        _filtroItem = filtroItem;
    }

    public override Expression CreateExpression(MemberExpression property, ConstantExpression constant)
    {
        var method = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })
                                                            ?? throw new ArgumentNullException();

        return Expression.Call(property, method, constant);
    }
}