namespace CsvHandler.Core.Domain.Constants;

public class QueryParams
{
    public string? SearchTerm { get; set; }
    public int PageSize { get; set; } = 2;
    public SortDirection SortDirection { get; set; } = SortDirection.Asc;
}