namespace Todo.Service.Application.Models;
public class PageResponse<T>
{
    public List<T> Content { get; set; }
    public Page Page { get; set; }

    public PageResponse() { }

    public PageResponse(List<T> content, int pageNumber, int pageLimit, int totalResult) : this(content, PageRequest.Of(pageNumber, pageLimit), totalResult) { }

    public PageResponse(List<T> content, PageRequest pageRequest, long totalResult)
    {
        this.Content = content;

        Page page = new()
        {
            Paged = totalResult > content.Count,
            Number = pageRequest.Number,
            Limit = pageRequest.Limit,
            Total = (int)totalResult
        };

        page.TotalPages = (int)Math.Ceiling((double)totalResult / (double)page.Limit);
        page.First = page.Number == 1;
        page.Last = page.Number >= page.Total;

        this.Page = page;
    }

    public static PageResponse<T> For(List<T> content, PageRequest pageRequest, long totalResult) => new(content, pageRequest, totalResult);
}
