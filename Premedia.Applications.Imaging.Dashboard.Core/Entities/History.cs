using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class History:EntityObject
{
    public string Action { get; set; }
    public string Field { get; set; }
    public string ErrorCode { get; set; }
    public string OldValue { get; set; }
    public string? NewValue { get; set; }
    public DateTime ChangeTime { get; set; }

    
    //relations
    public Guid EditorId { get; set; }
    public User Editor { get; set; } = null!;

    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}

