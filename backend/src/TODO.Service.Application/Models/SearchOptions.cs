namespace Todo.Service.Application.Models;
public struct SearchOptions
{
    public SearchOptions(int maxLimit, List<string> orderBy)
    {
        MaxLimit = maxLimit;
        OrderBy = orderBy ?? new List<string>();
    }

    public int MaxLimit { get; set; }
    public List<string> OrderBy { get; set; }
}

