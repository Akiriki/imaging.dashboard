namespace Premedia.Applications.Imaging.Dashboard.Core.Models;

public abstract class QueryBase
{
    public string? SearchString { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public bool? ShouldSortDescending { get; set; } = false;
    public List<string> PropListForSearch { get; set; }
}