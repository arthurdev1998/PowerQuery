namespace PowerQuery.Commons.Messages;

public class ServiceResult<T>
{   
    public T? Data { get; set; }
    public List<string> ErrorMessage { get; set; } =  [];
    public bool HasError { get; set; } = false;

    public ServiceResult()
    {
        HasError = false;
        ErrorMessage = [];
    }

    public ServiceResult(T obj)
    {
        Data = obj;
    }

    public ServiceResult(string errorMessage)
    {
        ErrorMessage.Add(errorMessage);
        HasError = true;
    }

    public ServiceResult(IEnumerable<string> errorsMessage)
    {
        
        ErrorMessage.AddRange(errorsMessage);
        HasError = true;
    }
}