namespace Application.Common.Models;

public class PaginationList<T>
{
    public IEnumerable<T> Data { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }

    private PaginationList(IEnumerable<T> data, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalCount = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Data = data;
    }

    public bool HasPrevious => PageNumber > 1;

    public bool HasNext => PageNumber < TotalPages;
    
    public static Task<PaginationList<T>> Create(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var data = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        
        return Task.FromResult(new PaginationList<T>(data, count, pageNumber, pageSize));
    }

}