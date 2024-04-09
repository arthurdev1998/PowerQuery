namespace PowerQuery.Entities.QueryRunners;

public class QueryRunner
{
    private static Dictionary<string, string> constants = new Dictionary<string, string>
    {
        {"Equals", "equals"},
        {"Contains", "contains"},
        {"StartsWith", "startWith"},
        {"LessThan", "lessThan"},
        {"GreaterThan", "greaterThan"}
    };

    public string? Property { get; set; }
    public string? FilterType { get; set; }
    public object? Value { get; set; }

    public static string FilterTypeConstants(string src)
    {
        var result = constants.FirstOrDefault(x => x.Key == src);

        if(result.Value == null){ throw new ArgumentNullException();}
        return result.Value;
    }
}