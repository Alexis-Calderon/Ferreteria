namespace Ferreteria.Domain.Models;

public class GetAllResponse<T>(int totalCount, int pageSize, int pageNumber, IEnumerable<T> items) where T : class
{
    public int TotalCount { get; set; } = totalCount;
    public int PageSize { get; set; } = pageSize;
    public int PageNumber { get; set; } = pageNumber;
    public IEnumerable<T> Items { get; set; } = items;
}