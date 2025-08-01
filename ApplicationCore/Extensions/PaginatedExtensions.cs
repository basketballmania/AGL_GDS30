using AGL.Api.ApplicationCore.Models;

namespace AGL.Api.ApplicationCore.Extensions
{
    public static class PaginatedExtensions
    {
        public static async Task<PaginatedList<T>> PaginatedListAsync<T>(this IQueryable<T> queryable, int pageNumber, int pageSize)
        {
            return await PaginatedList<T>.CreateAsync(queryable, pageNumber, pageSize);
        }

        public static async Task<PaginatedList<T>> PaginatedListAsync<T>(this IEnumerable<T> queryable, int pageNumber, int pageSize)
        {
            return await PaginatedList<T>.CreateAsync(queryable, pageNumber, pageSize);
        }
    }
}
