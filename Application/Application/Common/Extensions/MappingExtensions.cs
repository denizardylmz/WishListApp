using Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Extensions;

public static class QueryableExtensions
{
    public static Task<PaginationList<TDestination>> PaginationListAsync<TDestination>(
        this IQueryable<TDestination> queryable,
        int pageNumber,
        int pageSize) where TDestination : class
    {
        return PaginationList<TDestination>.Create(queryable.AsNoTracking(), pageNumber, pageSize);
    }
}