using System.Linq.Expressions;
using PowerQuery.Builder;
using PowerQuery.Models;

namespace PowerQuery.Factorys.Interpreters.Products;

public class LessThanInterpreter<T> : FilterTypeAbstractBuilder<T>
{
    public LessThanInterpreter(FiltroItem filtroItem): base(filtroItem)
    {
    }

    public override Expression CreateExpression(MemberExpression property, ConstantExpression constant)
    {
        return Expression.LessThan(property, constant);
    }
}
