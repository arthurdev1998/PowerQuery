using System.Text;

namespace PowerQuery.Commons.Messages;

public class ServiceResult<T> : ServiceResult
{
    public T? Data { get; set; }

    public ServiceResult(string str)
    {
        ErrorMessage.Append(str);
        HasError = true;
    }
}

public class ServiceResult
{
    public StringBuilder ErrorMessage { get; set; } = new StringBuilder();
    public bool HasError { get; set; } = false;

    public ServiceResult()
    {
        HasError = false;
    }
}