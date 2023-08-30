namespace Hupo.Template.Application.Common.Models;

public class PagedResultDto<T>
{
    public PagedResultDto(IReadOnlyCollection<T> items, int pageIndex, int pageSize, int count)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;
    public IReadOnlyCollection<T> Items { get; }

    public static async Task<PagedResultDto<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResultDto<T>(items, count, pageNumber, pageSize);
    }
}
