namespace Premedia.Applications.Imaging.Dashboard.Core.Models;

public class PagedResultModel<T> where T : class
{
    public List<T> ItemList { get; set; }
    public int ItemCount { get; set; }
}