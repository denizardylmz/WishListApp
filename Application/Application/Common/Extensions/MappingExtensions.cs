using Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Extensions;

public static class QueryableExtensions
{
    public static Task<PaginationList<TDestination>> PaginationListAsync<TDestination>(
        this IQueryable<TDestination> queryable,
        int pageNumber,
        int pageSize, CancellationToken cancellationToken = default) where TDestination : class
    {
        return PaginationList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize, cancellationToken);
    }
}