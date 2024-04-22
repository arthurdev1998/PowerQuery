using System.Linq.Expressions;
using PowerQuery.Builder;
using PowerQuery.Models;

namespace PowerQuery.Factorys.Interpreters.Products;

public class GreaterThanInterpreter<T> : FilterTypeAbstractBuilder<T>
{
    public GreaterThanInterpreter(FiltroItem filtroItem) : base(filtroItem)
    {
    }

    public override Expression CreateExpression(MemberExpression property, ConstantExpression constant)
    {
        return Expression.GreaterThan(property, constant);
    }
}