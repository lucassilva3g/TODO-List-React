namespace Todo.Service.Application.Models;
public class Page
{
    public int Number { get; set; }
    public int Limit { get; set; }
    public int Total { get; set; }
    public int TotalPages { get; set; }
    public bool Paged { get; set; }
    public bool First { get; set; }
    public bool Last { get; set; }
}
