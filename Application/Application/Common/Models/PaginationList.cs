using Microsoft.EntityFrameworkCore;

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
    
    public static async Task<PaginationList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var count = source.Count();
        var data = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        
        return new PaginationList<T>(data, count, pageNumber, pageSize);
    }

}