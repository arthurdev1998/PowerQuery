using PowerQuery.Commons.Constants;
using PowerQuery.Factorys.Interpreters.Products;
using PowerQuery.Interfaces.IProducts;
using PowerQuery.Models;

namespace PowerQuery.Factorys.Interpreters.Factory;

public static class FilterInterpreterFactory
{
    public static IFilterTypeInterpreter<T> Create<T>(FiltroItem filtroItem)
    {
        return filtroItem.Property switch
        {
            TypeConstants.Equals => new EqualsInterpreter<T>(filtroItem),
            TypeConstants.Contains => new ContainsInterpreter<T>(filtroItem),
            TypeConstants.GreaterThan => new GreaterThanInterpreter<T>(filtroItem),
            TypeConstants.LessThan => new LessThanInterpreter<T>(filtroItem),
            TypeConstants.StartsWith => new StartWithInterpreter<T>(filtroItem),
            _ => throw new ArgumentException($"Propriedade invalida {nameof(filtroItem.Property)}"),
        };
    }
}