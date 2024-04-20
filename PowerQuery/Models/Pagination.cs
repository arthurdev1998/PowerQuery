namespace PowerQuery.Models;

public class Pagination
{
    public List<FiltroItem> FiltroItem { get; set; } = new List<FiltroItem>();
    public int Take { get; set; }
    public int Skip { get; set; }
}