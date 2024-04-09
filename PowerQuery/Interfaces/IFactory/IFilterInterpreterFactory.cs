using PowerQuery.Interfaces.IProducts;
using PowerQuery.Models;

namespace PowerQuery.Interfaces.IFactory;

public interface IFilterInterpreterFactory
{
    IFilterTypeInterpreter<T> Create<T>(FiltroItem filtroItem);   
}