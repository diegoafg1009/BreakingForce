namespace Application.Contracts.FilterItem.DTOs;

public class FilterDto
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 15;
    public string? SortBy { get; set; }
    public bool IsSortAscending { get; set; } = true;
    public string? Search { get; set; }
}