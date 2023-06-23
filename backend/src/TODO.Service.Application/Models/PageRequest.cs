namespace Todo.Service.Application.Models;
public class PageRequest
{
    protected internal static readonly int DefaultPageLimit = 10;
    private int number;
    private int limit;
    public int Number { get { return number; } }
    public int Limit { get { return limit; } }

    private PageRequest() { }

    public static PageRequest Of(Nullable<int> number, Nullable<int> limit)
    {
        int n = number ?? 1;
        int l = limit ?? DefaultPageLimit;
        return Of(n, l);
    }

    public static PageRequest Of(int number, int limit)
    {
        PageRequest pr = new()
        {
            number = number < 1 ? 1 : number,
            limit = limit
        };

        return pr;
    }

    public static PageRequest First() => Of(1, DefaultPageLimit);
    public static PageRequest First(Nullable<int> limit) => Of(1, limit);

    public PageRequest WithMaxLimit(int maxLimit)
    {
        if (maxLimit > 0 && limit > maxLimit)
            limit = maxLimit;

        return this;
    }
}
