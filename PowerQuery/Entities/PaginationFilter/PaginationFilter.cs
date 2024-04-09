using PowerQuery.Entities.QueryRunners;

namespace PowerQuery.Entities.PaginationFilter;

public class PaginationFilter
{
    public List<QueryRunner> Querys{get; set;} = new List<QueryRunner>();
    public int Take { get; set; }
    public int Skip { get; set; } 
}