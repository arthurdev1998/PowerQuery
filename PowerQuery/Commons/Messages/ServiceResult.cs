using System.Text;

namespace PowerQuery.Commons.Messages;

public class ServiceResult<T> : ServiceResult
{
    internal T? Data { get; set; }

    public ServiceResult(string str)
    {
        ErrorMessage = new StringBuilder(str);
        HasError = true;
    }

    public ServiceResult(T data)
    {
        Data = data;
    }
}

public class ServiceResult
{
    internal StringBuilder ErrorMessage { get; set; } = new StringBuilder();
    internal bool HasError { get; set; } = false;

    public ServiceResult()
    {

    }
}