using Microsoft.EntityFrameworkCore;

namespace AGL.Api.ApplicationCore.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; init; }
        public int PageIndex { get; init; }
        public int TotalPages { get; init; }
        public int TotalCount { get; init; }
        public int PageSize { get; init; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex/ pageSize;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

		public bool HasPreviousPage => PageIndex + 1 > 1;
		public bool HasNextPage => ((PageIndex+ PageSize) / PageSize) < TotalPages;
		public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = new List<T>();

            if (pageSize > 0)
            {
                items = await source.Skip(pageIndex).Take(pageSize).ToListAsync();
            }
            else
            {
                items = await source.ToListAsync();
            }

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = new List<T>();

            if (pageSize > 0)
            {
                items = source.Skip(pageIndex).Take(pageSize).ToList();
            }
            else
            {
                items = source.ToList();
            }

            await Task.CompletedTask;
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
