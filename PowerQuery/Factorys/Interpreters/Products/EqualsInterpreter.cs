using System.Linq.Expressions;
using PowerQuery.Builder;
using PowerQuery.Models;

namespace PowerQuery.Factorys.Interpreters.Products;

public class EqualsInterpreter<T> : FilterTypeAbstractBuilder<T>
{
    public EqualsInterpreter(FiltroItem filtroItem) : base(filtroItem)
    {
    }

    public override Expression CreateExpression(MemberExpression property, ConstantExpression constant)
    {
        return Expression.Equal(property, constant);
    }
}