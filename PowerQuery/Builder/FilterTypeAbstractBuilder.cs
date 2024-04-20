using System.Linq.Expressions;
using System.Reflection;
using PowerQuery.Interfaces.IProducts;
using PowerQuery.Models;

namespace PowerQuery.Builder;

public abstract class FilterTypeAbstractBuilder<T> : IFilterTypeInterpreter<T>
{
    private readonly FiltroItem _filtroItem;

    public FilterTypeAbstractBuilder(FiltroItem filtroItem)
    {
        _filtroItem = filtroItem;
    }

    //Fazedor de Expressoes 
    public Expression<Func<T, bool>> Interpreter()
    {
        var dynamicType = typeof(T);
        var parameter = Expression.Parameter(dynamicType, dynamicType.Name.First().ToString());
        var property = Expression.Property(parameter, _filtroItem.Property!);
        var propertyInfo = (PropertyInfo)property.Member;
        var value = Convert.ChangeType(_filtroItem.Value?.ToString(), propertyInfo.PropertyType);
        var constant = Expression.Constant(value);
        var expression = CreateExpression(property, constant);

        var resultExpression = Expression.Lambda<Func<T, bool>>(expression, parameter);
        return resultExpression;
    }

    public abstract Expression CreateExpression(MemberExpression property, ConstantExpression constant);
}