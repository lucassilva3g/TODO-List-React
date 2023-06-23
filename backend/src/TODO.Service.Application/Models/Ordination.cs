namespace Todo.Service.Application.Models;

public struct Ordination
{
    public Ordination(string orderBy, bool asc)
    {
        OrderBy = orderBy;
        Asc = asc;
    }

    public string OrderBy { get; set; }
    public bool Asc { get; set; }
}
