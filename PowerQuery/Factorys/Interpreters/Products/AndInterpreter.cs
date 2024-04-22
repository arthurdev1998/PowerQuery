using System.Linq.Expressions;
using PowerQuery.Interfaces.IProducts;

namespace PowerQuery.Factorys.Interpreters.Products;

public class AndInterpreter<T> : IFilterTypeInterpreter<T>
{
    private readonly IFilterTypeInterpreter<T> _rightFilterTypeInterpreter;
    private readonly IFilterTypeInterpreter<T> _leftFilterTypeInterpreter;

    public AndInterpreter(IFilterTypeInterpreter<T> rightFilterTypeInterpreter,
                            IFilterTypeInterpreter<T> leftFilterTypeInterpreter)
    {
        _rightFilterTypeInterpreter = rightFilterTypeInterpreter;
        _leftFilterTypeInterpreter = leftFilterTypeInterpreter;
    }

    public Expression<Func<T, bool>> Interpreter()
    {
        var leftExpression = _leftFilterTypeInterpreter.Interpreter();
        var leftParameters = leftExpression.Parameters.FirstOrDefault() 
                            ?? throw new ArgumentNullException(nameof(leftExpression.Parameters));

        var rightExpression = Expression.Invoke(_rightFilterTypeInterpreter.Interpreter(), leftParameters);

        var andAlsoExpression = Expression.AndAlso(leftExpression.Body, rightExpression);

        return Expression.Lambda<Func<T, bool>>(andAlsoExpression, leftParameters);
    }
}